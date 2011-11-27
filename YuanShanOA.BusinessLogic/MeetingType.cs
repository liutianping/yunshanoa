using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YunShanOA.BusinessLogic
{
    public class MeetingType
    {
        /// <summary>
        /// 获取所以会议的名字和ID
        /// </summary>
        /// <returns></returns>
        public static List<Model.MeetingType> GetMeetingType()
        {
            return DALFactory.MeetingInstanceFactory.GetMeetingTypeInstance().GetMeetingType();
        }
    }
}
