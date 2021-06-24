using Eliza.Model;
using MessagePack;
using MessagePack.Formatters;
using System.Text;

namespace Eliza.Core.Serialization.MessagePackFormatters
{
    class FriendMonsterStatusDataFormatter : IMessagePackFormatter<FriendMonsterStatusData>
    {
        public FriendMonsterStatusData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            var friendMonsterStatusData = new FriendMonsterStatusData();

            IFormatterResolver resolver = options.Resolver;
            options.Security.DepthStep(ref reader);

            reader.ReadArrayHeader();

            //StatusDataBase
            friendMonsterStatusData.Level = reader.IsNil ? 0xFF : reader.ReadInt32();
            friendMonsterStatusData.Exp = reader.IsNil ? 0xFF : reader.ReadInt32();
            friendMonsterStatusData.Hp = reader.IsNil ? 0xFF : reader.ReadInt32();
            friendMonsterStatusData.Rp = reader.IsNil ? 0xFF : reader.ReadInt32();
            friendMonsterStatusData.SaveParameter = resolver.GetFormatterWithVerify<Parameter>().Deserialize(ref reader, options);
            friendMonsterStatusData.BadStatus = reader.IsNil ? 0xFF : reader.ReadInt32();
            friendMonsterStatusData.TemporaryStatus_UseItem = resolver.GetFormatterWithVerify<ItemData>().Deserialize(ref reader, options);
            friendMonsterStatusData.TemporaryStatus_UseItem_Time = reader.IsNil ? 0xFF : reader.ReadInt32();
            friendMonsterStatusData.TemporaryStatus_HotSpring = reader.IsNil ? 0xFF : reader.ReadInt32();
            friendMonsterStatusData.TemporaryStatus_HotSpring_Time = reader.IsNil ? 0xFF : reader.ReadInt32();
            friendMonsterStatusData.TemporaryStatus_Vaccination = reader.IsNil ? 0xFF : reader.ReadInt32();
            friendMonsterStatusData.TemporaryStatus_Vaccination_Time = reader.IsNil ? 0xFF : reader.ReadInt32();
            friendMonsterStatusData.Score_ATKUp_Level = reader.IsNil ? 0xFF : reader.ReadInt32();
            friendMonsterStatusData.Score_ATKUp_Time = reader.IsNil ? 0xFF : reader.ReadInt32();
            friendMonsterStatusData.Score_DEFUp_Level = reader.IsNil ? 0xFF : reader.ReadInt32();
            friendMonsterStatusData.Score_DEFUp_Time = reader.IsNil ? 0xFF : reader.ReadInt32();

            friendMonsterStatusData.DataID = reader.ReadUInt32();
            friendMonsterStatusData.Name = reader.ReadString();
            friendMonsterStatusData.MonsterDataID = reader.ReadInt32();
            reader.ReadMapHeader();
            reader.ReadString(); //LovePoint
            friendMonsterStatusData.LovePoint = reader.ReadInt32();
            friendMonsterStatusData.TimeStamp = reader.ReadInt32();
            friendMonsterStatusData.FarmId = reader.ReadInt32();
            friendMonsterStatusData.HouseId = reader.ReadInt32();
            friendMonsterStatusData.RoomId = reader.ReadInt32();
            friendMonsterStatusData.PartyNo = reader.ReadInt32();
            friendMonsterStatusData.PartnerMovementOrderType = reader.ReadInt32();
            friendMonsterStatusData.FarmMonsterOrder = reader.ReadInt32();
            friendMonsterStatusData.FarmFieldWorkArea = reader.ReadInt32();
            friendMonsterStatusData.IsBrushed = reader.ReadBoolean();
            friendMonsterStatusData.IsPresent = reader.ReadBoolean();
            friendMonsterStatusData.EsaGet = reader.ReadBoolean();
            friendMonsterStatusData.IsWorkedToday = reader.ReadBoolean();
            friendMonsterStatusData.IsSeededToday = reader.ReadBoolean();
            friendMonsterStatusData.IsYieldToday = reader.ReadBoolean();
            friendMonsterStatusData.Bonus_HP = reader.ReadInt32();
            friendMonsterStatusData.Bonus_STR = reader.ReadInt32();
            friendMonsterStatusData.Bonus_INT = reader.ReadInt32();
            friendMonsterStatusData.Bonus_VIT = reader.ReadInt32();
            return friendMonsterStatusData;

        }

        public void Serialize(ref MessagePackWriter writer, FriendMonsterStatusData value, MessagePackSerializerOptions options)
        {
            IFormatterResolver resolver = options.Resolver;

            writer.WriteArrayHeader(38);
            writer.Write(value.Level);
            writer.Write(value.Exp);
            writer.Write(value.Hp);
            writer.Write(value.Rp);
            resolver.GetFormatterWithVerify<Parameter>().Serialize(ref writer, value.SaveParameter, options);
            writer.Write(value.BadStatus);
            resolver.GetFormatterWithVerify<ItemData>().Serialize(ref writer, value.TemporaryStatus_UseItem, options);
            writer.Write(value.TemporaryStatus_UseItem_Time);
            writer.Write(value.TemporaryStatus_HotSpring);
            writer.Write(value.TemporaryStatus_HotSpring_Time);
            writer.Write(value.TemporaryStatus_Vaccination);
            writer.Write(value.TemporaryStatus_Vaccination_Time);
            writer.Write(value.Score_ATKUp_Level);
            writer.Write(value.Score_ATKUp_Time);
            writer.Write(value.Score_DEFUp_Level);
            writer.Write(value.Score_DEFUp_Time);

            writer.Write(value.DataID);
            writer.Write(value.Name);
            writer.Write(value.MonsterDataID);
            writer.WriteMapHeader(1);
            writer.WriteString(Encoding.UTF8.GetBytes("LovePoint"));
            writer.Write(value.LovePoint);
            writer.Write(value.TimeStamp);
            writer.Write(value.FarmId);
            writer.Write(value.HouseId);
            writer.Write(value.RoomId);
            writer.Write(value.PartyNo);
            writer.Write(value.PartnerMovementOrderType);
            writer.Write(value.FarmMonsterOrder);
            writer.Write(value.FarmFieldWorkArea);
            writer.Write(value.IsBrushed);
            writer.Write(value.IsPresent);
            writer.Write(value.EsaGet);
            writer.Write(value.IsWorkedToday);
            writer.Write(value.IsSeededToday);
            writer.Write(value.IsYieldToday);
            writer.Write(value.Bonus_HP);
            writer.Write(value.Bonus_STR);
            writer.Write(value.Bonus_INT);
            writer.Write(value.Bonus_VIT);
        }
    }
}
