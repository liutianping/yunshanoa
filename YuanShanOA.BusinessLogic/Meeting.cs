using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YunShanOA.IDAL.MeetingInterface;


namespace YunShanOA.BusinessLogic
{
    
    public class Meeting
    {
        private static readonly IMeetingApply meetingApply = YunShanOA.DALFactory.MeetingInstanceFactory.GetMeetingApplyInstance();

        public static List<YunShanOA.Model.Meeting> ListMeetingByStaus(int status)
        {
            return meetingApply.GetListMeetingApplyByStatus(status);
        }

        public static Guid GetGuidByApplyForm(int applyFormID)
        {
            return meetingApply.GetGuidByApplyFormID(applyFormID);
        }

        public static Model.Meeting GetApplyMeetingInfoByMeeingID(int meetingAppltFormID)
        {
            return DALFactory.MeetingInstanceFactory.GetMeetingApplyInstance().GetApplyMeetingInfoByMeeingID(meetingAppltFormID);
        }

        public static void UpdateReviewMeetingApplyState(int meetingApplyFormID, string userName, int newState)
        {
            DALFactory.MeetingInstanceFactory.GetMeetingApplyInstance().UpdateReviewMeetingApplyState(meetingApplyFormID,userName,newState);
        }

        public static int GetMeetingApplyFormIDByGUID(Guid guid)
        {
            return DALFactory.MeetingInstanceFactory.GetMeetingApplyInstance().GetMeetingApplyFormIDByGUID(guid);
        }

        public static string GetUserNameByApplyFormID(int meetingApplyFromID)
        {
            return DALFactory.MeetingInstanceFactory.GetMeetingApplyInstance().GetUserNameByApplyFormID(meetingApplyFromID);
        }

        public static void UpdateMeetingApplyFormStatus(int meetingApplyFormID, int newStatus)
        {
            DALFactory.MeetingInstanceFactory.GetMeetingApplyInstance().UpdateMeetingApplyFormStatus(meetingApplyFormID, newStatus);

        }
    }
}
