using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace YunShanOA.Model
{
    public class MeetingRoom
    {
        private int _meetingRoomID = -1;

        public int MeetingRoomID
        {
            get { return _meetingRoomID; }
            set { _meetingRoomID = value; }
        }
        public string MeetingRoomName { get; set; }
        public int MeetingRoomCapacity { get; set; }
        public int MeetingRoomStatus { get; set; }
        public int MeetingTypeID { get; set; }

        public MeetingRoom()
        { }
    }

}
