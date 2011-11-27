﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YunShanOA.Model;

namespace YunShanOA.IDataAccess.IMeeting
{
    public interface IMeetingUser
    {
        List<UserInfo> GetUserEmailAndName();
        UserInfo GetUserInfoByUserName(string userName);
        List<UserInfo> GetUserEmailAndNameByRoleName(string roleName);
        List<UserInfo> GetUserRoleNameList();
        List<UserInfo> GetUserEmailAndNameListByApplyFormID(int meetingApplyFormID);
        string UserEmailByUserName(string userName);
        List<Model.AttendMeetingInfo> ListAttendMeetingByUserName(string userName);

    }
}
