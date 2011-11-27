using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YunShanOA.Model
{
    public class Meeting
    {
        public string MeetingTopic { get; set; }
        public string MeetingIntroduction { get; set; }
        public DateTime BeginTime { get; set; }
        public DateTime EndTime { get; set; }
        public int MeetingStatus { get; set; }
        public string Comments { get; set; }
        public Guid WFID { get; set; }
        public int MeetingApplyFormID { get; set; }
        public int MeetingTypeID { get; set; }
        public string ApplyUserName { get; set; }
    }
}
