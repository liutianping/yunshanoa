using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YunShanOA.Model
{
    public class ArrMeetingEquipmentInfo
    {
        public int MeetingEquipmentID { get; set; }
         public int MeetingApplyFormID { get; set; }
         public DateTime BeginTime { get; set; }
         public DateTime EndTime { get; set; }
         public string MeetingRoomName { get; set; }
         public string EquipmentName { get; set; }
         public int EquipmentCount { get; set; }
         public int MeetingAndRoomID { get; set; }
         public int MeetingRoomID { get; set; }
    }
}
