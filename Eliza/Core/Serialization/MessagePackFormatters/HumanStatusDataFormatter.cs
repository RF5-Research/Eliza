using Eliza.Model;
using MessagePack;
using MessagePack.Formatters;
using System.Text;

namespace Eliza.Core.Serialization.MessagePackFormatters
{
    class HumanStatusDataFormatter : IMessagePackFormatter<HumanStatusData>
    {
        public HumanStatusData Deserialize(ref MessagePackReader reader, MessagePackSerializerOptions options)
        {
            var humanStatusData = new HumanStatusData();

            IFormatterResolver resolver = options.Resolver;
            options.Security.DepthStep(ref reader);

            reader.ReadArrayHeader();

            //StatusDataBase
            humanStatusData.Level = reader.TryReadNil() ? -1 : reader.ReadInt32();
            humanStatusData.Exp = reader.TryReadNil() ? -1 : reader.ReadInt32();
            humanStatusData.Hp = reader.TryReadNil() ? -1 : reader.ReadInt32();
            humanStatusData.Rp = reader.TryReadNil() ? -1 : reader.ReadInt32();
            humanStatusData.SaveParameter = resolver.GetFormatterWithVerify<Parameter>().Deserialize(ref reader, options);
            humanStatusData.BadStatus = reader.TryReadNil() ? -1 : reader.ReadInt32();
            humanStatusData.TemporaryStatus_UseItem = resolver.GetFormatterWithVerify<ItemData>().Deserialize(ref reader, options);
            humanStatusData.TemporaryStatus_UseItem_Time = reader.TryReadNil() ? -1 : reader.ReadInt32();
            humanStatusData.TemporaryStatus_HotSpring = reader.TryReadNil() ? -1 : reader.ReadInt32();
            humanStatusData.TemporaryStatus_HotSpring_Time = reader.TryReadNil() ? -1 : reader.ReadInt32();
            humanStatusData.TemporaryStatus_Vaccination = reader.TryReadNil() ? -1 : reader.ReadInt32();
            humanStatusData.TemporaryStatus_Vaccination_Time = reader.TryReadNil() ? -1 : reader.ReadInt32();
            humanStatusData.Score_ATKUp_Level = reader.TryReadNil() ? -1 : reader.ReadInt32();
            humanStatusData.Score_ATKUp_Time = reader.TryReadNil() ? -1 : reader.ReadInt32();
            humanStatusData.Score_DEFUp_Level = reader.TryReadNil() ? -1 : reader.ReadInt32();
            humanStatusData.Score_DEFUp_Time = reader.TryReadNil() ? -1 : reader.ReadInt32();

            humanStatusData.ActorID = reader.TryReadNil() ? -1 : reader.ReadInt32();
            reader.ReadMapHeader();
            reader.ReadString();  //E

            var humanEquip = new HumanEquip();
            //var length = reader.ReadArrayHeader();
            //var list = new ItemData[length];

            //for (int i = 0; i < length; i++)
            //{
            //    list[i] = resolver.GetFormatterWithVerify<ItemData>().Deserialize(ref reader, options);
            //}
            humanEquip.EquipItems = resolver.GetFormatterWithVerify<ItemData[]>().Deserialize(ref reader, options);
            humanStatusData.HumanEquip = humanEquip;
            humanStatusData.PartnerMovementOrderType = reader.TryReadNil() ? -1 : reader.ReadInt32();
            humanStatusData.DualSkillGauge = (float)reader.ReadDouble();

            return humanStatusData;
        }

        public void Serialize(ref MessagePackWriter writer, HumanStatusData value, MessagePackSerializerOptions options)
        {
            IFormatterResolver resolver = options.Resolver;

            writer.WriteArrayHeader(20);
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

            writer.Write(value.ActorID);
            writer.WriteMapHeader(1);
            writer.WriteString(Encoding.UTF8.GetBytes("E"));
            resolver.GetFormatterWithVerify<ItemData[]>().Serialize(ref writer, value.HumanEquip.EquipItems, options);
            writer.Write(value.PartnerMovementOrderType);
            writer.Write(value.DualSkillGauge);
        }
    }
}