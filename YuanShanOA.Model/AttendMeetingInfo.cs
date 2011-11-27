using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YunShanOA.Model
{
    public class AttendMeetingInfo
    {
       public string MeetingRoomName { get; set; }
       public DateTime BeginTime { get; set; }
       public DateTime EndTime { get; set; }
       public string MeetingTopic { get; set; }
       public string MeetingIntroduction { get; set; }
    }
}
