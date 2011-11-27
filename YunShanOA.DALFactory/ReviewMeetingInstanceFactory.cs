using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using YunShanOA.IDataAccess;
using System.Reflection;

namespace YunShanOA.DALFactory
{
    public class ReviewMeetingInstanceFactory
    {
        private static readonly string PATH = ConfigurationManager.AppSettings["SqlServerDataAccess"];
        public static IReviewMeeting GetReviewMeetingInstance()
        {
            return (IReviewMeeting)Assembly.Load(PATH).CreateInstance(PATH + ".ReviewMeeting.ReviewMeeting");
        }
    }
}
