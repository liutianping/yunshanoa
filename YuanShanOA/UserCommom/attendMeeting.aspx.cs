using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YunShanOA.UserCommom
{
    public partial class attendMeeting : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Master.Holdermenu7 = "会议管理&nbsp;»&nbsp;待参加会议";
            string username = string.Empty;
            if (null == Page.User.Identity.Name)
            {
                Response.Redirect("~/Login.aspx");
               
            }
            else
            {
                username = Page.User.Identity.Name;
            }
            if (!Page.IsPostBack)
            {
                gvAttendMeeting.DataSource = BusinessLogic.MeetingUser.ListAttendMeetingByUserName(username);
                gvAttendMeeting.DataBind();
            }
        }
    }
}