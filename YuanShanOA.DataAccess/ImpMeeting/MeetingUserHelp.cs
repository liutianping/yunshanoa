using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YunShanOA.IDataAccess.IMeeting;

namespace YunShanOA.DataAccess.ImpMeeting
{
    public class MeetingUserHelp : IMeetingUser
    {

        #region IMeetingUser 成员
        YunShanOA.DataAccess.Mapping.YunShanOADataContext db = new Mapping.YunShanOADataContext();

        public List<Model.UserInfo> GetUserEmailAndNameListByApplyFormID(int meetingApplyFormID)
        {
            List<Model.UserInfo> list = new List<Model.UserInfo>();
            var q = (from u in db.aspnet_Users
                     join member in db.aspnet_Membership on u.UserId equals member.UserId
                     join mau in db.MeetingAndUser on u.UserName equals mau.UserName
                     where mau.MeetingApplyFormID == meetingApplyFormID
                     select new { member.Email, u.UserName }).ToList();
            list = q.Select(
                t => new Model.UserInfo() { UserEmail = t.Email, UserName = t.UserName }).ToList();
            return list;
        }

        public List<Model.UserInfo> GetUserEmailAndName()
        {
            List<Model.UserInfo> list = new List<Model.UserInfo>();
            var q = (from u in db.aspnet_Users
                     join ur in db.aspnet_UsersInRoles on u.UserId equals ur.UserId
                     join r in db.aspnet_Roles on ur.RoleId equals r.RoleId
                     join m in db.aspnet_Membership on u.UserId equals m.UserId
                     select new { u.UserName, r.RoleName, m.Email }).ToList();
            List<Model.UserInfo> uSet = q.Select(
                t => new Model.UserInfo()
                {
                    UserEmail = t.Email,
                    UserRoleName = t.RoleName,
                    UserName = t.UserName
                }).ToList();

            return uSet;
        }

        public List<Model.UserInfo> GetUserEmailAndNameByRoleName(string roleName)
        {

            var q = (from u in db.aspnet_Users
                     join ur in db.aspnet_UsersInRoles on u.UserId equals ur.UserId
                     join r in db.aspnet_Roles on ur.RoleId equals r.RoleId
                     join m in db.aspnet_Membership on u.UserId equals m.UserId
                     where r.RoleName.Equals(roleName)
                     select new { u.UserName, r.RoleName, m.Email }).ToList();
            List<Model.UserInfo> uSet = q.Select(
                t => new Model.UserInfo()
                {
                    UserEmail = t.Email,
                    UserRoleName = t.RoleName,
                    UserName = t.UserName
                }).ToList();

            return uSet;
        }

        public Model.UserInfo GetUserInfoByUserName(string userName)
        {
            throw new NotImplementedException();
        }

        public List<Model.UserInfo> GetUserRoleNameList()
        {
            var query = (from r in db.aspnet_Roles select new { r.RoleName }).ToList();
            List<Model.UserInfo> result = query.Select(
                q => new Model.UserInfo() { UserRoleName = q.RoleName }).ToList();
            return result;
        }

        public string UserEmailByUserName(string userName)
        {
            var q = (from userCurrName in db.aspnet_Membership
                     join user in db.aspnet_Users on userCurrName.UserId equals user.UserId
                     where user.UserName == userName
                     select userCurrName.Email).First();
            return q;
        }

        public List<Model.AttendMeetingInfo> ListAttendMeetingByUserName(string userName)
        {
            List<Model.AttendMeetingInfo> result = new List<Model.AttendMeetingInfo>();
            var q = (from meeting in db.MeetingApplyForm
                     join mau in db.MeetingAndRoom
                     on meeting.MeetingApplyFormID equals mau.MeetingApplyFormID
                     join mr in db.MeetingRoom
                     on mau.MeetingRoomID equals mr.MeetingRoomID
                     where meeting.MeetingStatus == 1 && meeting.EndTime > DateTime.Now
                     select new
                     {
                         mr.MeetingRoomName,
                         meeting.BeginTime,
                         meeting.EndTime,
                         meeting.MeetingTopic,
                         meeting.MeetingIntroduction
                     }).ToList();
            result = q.Select(t => new Model.AttendMeetingInfo()
            {
                MeetingRoomName = t.MeetingRoomName,
                BeginTime = t.BeginTime,
                EndTime = t.EndTime,
                MeetingIntroduction = t.MeetingIntroduction,
                MeetingTopic = t.MeetingTopic
            }).ToList();
            return result;
        }

        #endregion
    }
}
