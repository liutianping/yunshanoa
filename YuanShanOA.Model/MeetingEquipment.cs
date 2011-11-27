using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YunShanOA.Model
{
    public class MeetingEquipment
    {
        public int MeetingEquipmentID { get; set; }
        public string EquipmentName { get; set; }
        public string EquipmentDescription { get; set; }
        public int? Status { get; set; }
        public int MeetingEquipmentCount { get; set; }
        public int MeetingEquipmentFreeCount { get; set; }
        public string Comments { get; set; }
    }
}
