using Eliza.Model.RF5Shipping;
using System.Collections.Generic;
using static Eliza.Core.Serialization.Attributes;

namespace Eliza.Model.SaveData
{
    public class RF5ShippingData
    {
        public int completedPercent;
        public long totalIncome;
        [MessagePackList]
        //List<ShipmentItemRecords>[]
        public List<ShipmentItemRecords> ItemRecordList1;
        [MessagePackList]
        public List<ShipmentItemRecords> ItemRecordList2;
        [MessagePackList]
        public List<ShipmentItemRecords> ItemRecordList3;
        [MessagePackList]
        public List<ShipmentItemRecords> ItemRecordList4;
        [MessagePackList]
        public List<ShipmentItemRecords> ItemRecordList5;
        [MessagePackList]
        public List<ShipmentItemRecords> ItemRecordList6;
        [MessagePackList]
        public List<ShipmentItemRecords> ItemRecordList7;
        [MessagePackList]
        public List<ShipmentItemRecords> ItemRecordList8;
        [MessagePackList]
        public List<FishShipmentRecords> FishRecordList;
        [MessagePackList]
        public List<SeedLevelRecords> SeedLevelRecordList;

    }
}