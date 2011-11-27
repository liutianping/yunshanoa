using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace YunShanOA.AJAX
{
    /// <summary>
    /// GetAttendMeetingInfo 的摘要说明
    /// </summary>
    public class GetAttendMeetingInfo : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string userName=context.Request.QueryString["userName"];
            List<Model.AttendMeetingInfo> listresult = BusinessLogic.MeetingUser.ListAttendMeetingByUserName(userName);
            if (0 != listresult.Count)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("前5条会议主题如下:");
                foreach (var item in listresult)
                {
                    sb.Append("<br />");
                    sb.Append(item.MeetingTopic);
                }
                context.Response.Write(sb.ToString());
            }
            
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}