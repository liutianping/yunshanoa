using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YunShanOA.UserControl
{
    public partial class AttendMeeting : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string userName = Page.User.Identity.Name;
                if (!string.IsNullOrEmpty(userName))
                {
                    int meetingCount = BusinessLogic.MeetingUser.ListAttendMeetingByUserName(userName).Count;
                    string message = string.Empty;
                    if (0 != meetingCount)
                        message = "您有<a id='mettingCount' href='../UserCommom/attendMeeting.aspx'>" + meetingCount + "</a>个会议要参加。";
                    else
                        message = "暂无会议要参加";
                    ltl.Text = message;
                }
            }
        }
    }
}