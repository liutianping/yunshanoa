using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YunShanOA.BusinessLogic
{
    public class MeetingUser
    {
        public static List<Model.UserInfo> GetLiseUserInfoByRoleName(string userName)
        {
            return DALFactory.MeetingInstanceFactory.GetMeetingUserInstance().GetUserEmailAndNameByRoleName(userName);
        }

        public static List<Model.UserInfo> GetUserRoleName()
        {
            return DALFactory.MeetingInstanceFactory.GetMeetingUserInstance().GetUserRoleNameList();
        }

        public static List<Model.UserInfo> GetUserEmailAndName()
        {
            return DALFactory.MeetingInstanceFactory.GetMeetingUserInstance().GetUserEmailAndName();
        }

        public static List<Model.UserInfo> GetUserEmailAndNameByMeetingApplyFormID(int meetingApplyFormID)
        {
            return DALFactory.MeetingInstanceFactory.GetMeetingUserInstance().GetUserEmailAndNameListByApplyFormID(meetingApplyFormID);
        }

        public static string GetUserEmailByUserName(string userName)
        {
            return DALFactory.MeetingInstanceFactory.GetMeetingUserInstance().UserEmailByUserName(userName);
        }

        //根据用户名获取用户的待参加的会议列表
        public static List<Model.AttendMeetingInfo> ListAttendMeetingByUserName(string userName)
        {
            return DALFactory.MeetingInstanceFactory.GetMeetingUserInstance().ListAttendMeetingByUserName(userName);
        }
    }
}
