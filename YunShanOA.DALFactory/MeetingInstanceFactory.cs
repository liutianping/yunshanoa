using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YunShanOA.IDAL.MeetingInterface;
using System.Reflection;
using System.Configuration;
using System.Web.Configuration;
using YunShanOA.IDataAccess.IMeeting;


namespace YunShanOA.DALFactory
{
    public static class MeetingInstanceFactory
    {
        private static readonly string PATH = ConfigurationManager.AppSettings["SqlServerDataAccess"];
        /// <summary>
        /// 获取IMeetingType的实例
        /// </summary>
        /// <returns></returns>
        public static IMeetingType GetMeetingTypeInstance()
        {
            string className = PATH + ".Meeting.MeetingTypeHelp";
            
            return (IMeetingType)Assembly.Load(PATH).CreateInstance(className);
        }

        /// <summary>
        /// 获取IMeetingRoom的实例
        /// </summary>
        /// <returns></returns>
        public static IMeetingRoom GetMeetingRoomInstance()
        {
            string className = PATH + ".ImpMeeting.MeetingRoomHelp";
            return (IMeetingRoom)Assembly.Load(PATH).CreateInstance(className);
        }

        /// <summary>
        /// 获取IMeetingApply的实例
        /// </summary>
        /// <returns></returns>
        public static IMeetingApply GetMeetingApplyInstance()
        {
            string className = PATH + ".ImpMeeting.MeetingApplyHelp";
            return (IMeetingApply)Assembly.Load(PATH).CreateInstance(className);
        }
        /// <summary>
        /// 获取IMeetingEquipment的实例
        /// </summary>
        /// <returns></returns>
        public static IMeetingEquipment GetMeetingEquipmentInstance()
        {
            string className = PATH + ".ImpMeeting.MeetingEquipmentHelp";
            return (IMeetingEquipment)Assembly.Load(PATH).CreateInstance(className);
        }

        /// <summary>
        /// 获取IMeetingUserHelp的实例
        /// </summary>
        /// <returns></returns>
        public static IMeetingUser GetMeetingUserInstance()
        {
            string className = PATH + ".ImpMeeting.MeetingUserHelp";
            return (IMeetingUser)Assembly.Load(PATH).CreateInstance(className);
        }
    }
}
