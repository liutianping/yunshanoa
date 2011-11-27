using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YunShanOA.Model
{
    public class ReviewMeeting
    {
        int reviewMeetingApplyID;

        public int ReviewMeetingApplyID
        {
            get { return reviewMeetingApplyID; }
            set { reviewMeetingApplyID = value; }
        }
        Meeting _meetingApplyForm;

        public Meeting MeetingApplyForm
        {
            get { return _meetingApplyForm; }
            set { _meetingApplyForm = value; }
        }
        string status;

        public string GetStatus()
        {
            return status;
        }
        public void SetStatus(int statu)
        {
            if (1 == statu)
                status= "同意";
            else
                status= "不同意";
        }
    }
}
