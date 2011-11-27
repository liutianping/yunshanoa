using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace YunShanOA.AJAX
{
    /// <summary>
    /// MeetingRoomRadioButtonList 的摘要说明
    /// </summary>
    public class MeetingRoomRadioButtonList : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            
            DateTime beginTime = DateTime.Parse(context.Request.QueryString["beginTime"]);
            DateTime endTime = DateTime.Parse(context.Request.QueryString["endTime"]);

            List<Model.MeetingRoom> listResult = BusinessLogic.MeetingRoom.GetListMeetingRoomNotIn(beginTime, endTime);
            StringBuilder sb = new StringBuilder();
           
            foreach (var item in listResult)
            {
                sb.Append(string.Format("<input type='radio' name='radioMeetingRoom' value={0}>{1}",item.MeetingRoomID,item.MeetingRoomName));
            }
            context.Response.Write(sb.ToString());
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