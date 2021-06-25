using Eliza.Model;
using MessagePack;
using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using static Eliza.Core.Serialization.Attributes;

namespace Eliza.Core.Serialization
{
    class BinarySerializer : BinarySerialization
    {
        public BinaryWriter Writer;

        public BinarySerializer(Stream baseStream) : base(baseStream)
        {
            Writer = new BinaryWriter(baseStream);
        }

        public void Serialize<T>(T obj)
        {
            WriteValue(obj);
        }

        private void WriteValue(object value)
        {
            var type = value.GetType();

            if (type.IsPrimitive)
            {
                WritePrimitive(value);
            }
            else if (IsList(type))
            {
                WriteList((IList)value);
            }
            else if (type == typeof(string))
            {
                WriteString((string)value);
            }
            else if (type == typeof(SaveFlagStorage))
            {
                WriteSaveFlagStorage((SaveFlagStorage)value);
            }
            else if (type == typeof(Model.SaveData.SaveDataFooter))
            {
                WriteSavaDataFooter((Model.SaveData.SaveDataFooter)value);
            }
            else if (IsDictionary(type))
            {
                WriteDictionary((IDictionary)value);
            }
            else
            {
                WriteObject(value);
            }
        }
        
        private void WritePrimitive(object value)
        {
            var type = value.GetType();

            switch (Type.GetTypeCode(type))
            {
                case TypeCode.Boolean: Writer.Write((bool)value); break;
                case TypeCode.Byte: Writer.Write((byte)value); break;
                case TypeCode.Char: Writer.Write((char)value); break;
                case TypeCode.UInt16: Writer.Write((ushort)value); break;
                case TypeCode.UInt32: Writer.Write((uint)value); break;
                case TypeCode.UInt64: Writer.Write((ulong)value); break;
                case TypeCode.SByte: Writer.Write((sbyte)value); break;
                case TypeCode.Int16: Writer.Write((short)value); break;
                case TypeCode.Int32: Writer.Write((int)value); break;
                case TypeCode.Int64: Writer.Write((long)value); break;
                case TypeCode.Single: Writer.Write((float)value); break;
                case TypeCode.Double: Writer.Write((double)value); break;
            }
        }
        
        private void WriteList(IList list, TypeCode lengthType = TypeCode.Int32, int length = 0, int max = 0, bool isMessagePackList = false)
        {
            if (length == 0)
            {
                switch (lengthType)
                {
                    case TypeCode.Byte: Writer.Write((byte)list.Count); break;
                    case TypeCode.Char: Writer.Write((char)list.Count); break;
                    case TypeCode.UInt16: Writer.Write((ushort)list.Count); break;
                    case TypeCode.UInt32: Writer.Write((uint)list.Count); break;
                    case TypeCode.UInt64: Writer.Write((ulong)list.Count); break;
                    case TypeCode.SByte: Writer.Write((sbyte)list.Count); break;
                    case TypeCode.Int16: Writer.Write((short)list.Count); break;
                    case TypeCode.Int32: Writer.Write((int)list.Count); break;
                    case TypeCode.Int64: Writer.Write((long)list.Count); break;
                }
            }

            foreach (object value in list)
            {
                if (isMessagePackList)
                {
                    WriteMessagePackObject(value);
                }
                else
                {
                    WriteValue(value);
                }
            }
            //The only instance of the use of max, doesn't seem to have an effect regardless of the length is (i.e. FurnitureData)
        }

        private void WriteString(string value, int max = 0)
        {
            var data = Encoding.Unicode.GetBytes(value);
            if (max != 0)
            {
                Writer.Write(data.Length);
                for (int index = 0; index < max; index++)
                {
                    if (index < data.Length)
                    {
                        Writer.Write(data[index]);
                    }
                    else
                    {
                        Writer.Write((byte)0x0);
                    }
                }
            }
            else
            {
                // This assumes everything else adds 0 to the end. Might need another attribute
                for (int index = 0; index < data.Length; index++)
                {
                    Writer.Write(data[index]);
                    Writer.Write((byte)0x0);
                }
                Writer.Write((byte)0x0);
                Writer.Write((byte)0x0);
                //for (int index = 0; index < data.Length; index++)
                //{
                //    Writer.Write(data[index]);
                //}
            }
            return;
        }
        private void WriteSaveFlagStorage(SaveFlagStorage saveFlagStorage)
        {
            Writer.Write(saveFlagStorage.Length);
            Writer.Write(saveFlagStorage.Data);
        }

        private void WriteSavaDataFooter(Model.SaveData.SaveDataFooter footer)
        {
            using (var reader = new BinaryReader(BaseStream))
            {
                var bodyLength = BaseStream.Length;
                //Aligned relative to data 256 bytes due to Rijndael crypto
                var paddedSize = (int)((BaseStream.Position - 0x20 + 0xFF) & ~0xFF) + 0x20;
                BaseStream.SetLength(paddedSize);

                BaseStream.Position = 0x0;
                var headerSize = 0x20;
                var header = reader.ReadBytes(headerSize);

                var data = reader.ReadBytes(paddedSize - headerSize);

                //var encryptedData = Cryptography.Encrypt(data);
                var encryptedData = data;

                //Overwrite save data with encrypted data
                BaseStream.Position = headerSize;
                Writer.Write(encryptedData);

                var bodyData = new List<byte>();
                bodyData.AddRange(header);
                bodyData.AddRange(encryptedData);
                var checksum = Cryptography.Checksum(bodyData.ToArray());

                Writer.Write((int)bodyLength);
                Writer.Write(paddedSize);
                Writer.Write(checksum);
                Writer.Write((int)0x0);
            }
        }

        private void WriteDictionary(IDictionary dictionary)
        {
            Writer.Write(dictionary.Count);

            foreach (DictionaryEntry item in dictionary)
            {
                WriteValue(item.Key);
                WriteValue(item.Value);
            }
        }

        private void WriteObject(object objectValue)
        {
            var objectType = objectValue.GetType();

            // MessagePackObject
            if (objectType.IsDefined(typeof(MessagePackObjectAttribute)))
            {
                WriteMessagePackObject(objectValue);
                return;
            }

            int fieldCount = 0;

            foreach (FieldInfo info in GetFieldsSorted(objectType))
            {
                fieldCount++;

                if (!info.IsDefined(typeof(CompilerGeneratedAttribute)))
                {
                    object fieldValue = info.GetValue(objectValue);

                    Type fieldType = info.FieldType;

                    var messagePackListAttribute = (MessagePackListAttribute)info.GetCustomAttribute(typeof(MessagePackListAttribute));
                    if (messagePackListAttribute != null)
                    {
                        if (IsList(fieldType))
                        {
                            WriteList((IList)fieldValue, isMessagePackList: true);
                            continue;
                        }
                    }

                    var messagePackRawAttribute = (MessagePackRawAttribute)info.GetCustomAttribute(typeof(MessagePackRawAttribute));
                    if (messagePackRawAttribute != null)
                    {
                        WriteMessagePackObject(fieldValue);
                        continue;
                    }

                    var lengthAttribute = (LengthAttribute)info.GetCustomAttribute(typeof(LengthAttribute));
                    if (lengthAttribute != null)
                    {
                        if (lengthAttribute.Size != 0)
                        {
                            if (IsList(fieldType))
                            {
                                WriteList((IList)fieldValue, length: lengthAttribute.Size);
                                continue;
                            }
                            else if (fieldType == typeof(string))
                            {
                                WriteString((string)fieldValue, lengthAttribute.Size);
                                continue;
                            }
                        }
                        else if (lengthAttribute.Type != TypeCode.Empty)
                        {
                            if (IsList(fieldType))
                            {
                                WriteList((IList)fieldValue, lengthType: lengthAttribute.Type);
                                continue;
                            }
                            else if (fieldType == typeof(string))
                            {
                                //Not supported for strings ATM
                            }
                        }
                        else if (lengthAttribute.Max != 0)
                        {
                            if (IsList(fieldType))
                            {
                                WriteList((IList)fieldValue, max: lengthAttribute.Max);
                                continue;
                            }
                            else if (fieldType == typeof(string))
                            {
                                WriteString((string)fieldValue, max: lengthAttribute.Max);
                                continue;
                            }
                        }
                    }
                    WriteValue(fieldValue);
                }
            }

        }

        private void WriteMessagePackObject(object value)
        {
            var bytes = MessagePackSerializer.Serialize(value);
            Writer.Write(bytes.Length);
            Writer.Write(bytes);
        }
    }
}
