using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YunShanOA.Model
{
    public class MeetingType
    {

        private int _meetingTypeID=-1;

        public int MeetingTypeID
        {
            get { return _meetingTypeID; }
            set { _meetingTypeID = value; }
        }
        public string MeetingTypeName { get; set; }
        public string MeetingTypeDescription { get; set; }
    }
}
