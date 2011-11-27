using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YunShanOA.OfficeAdmin
{
    public partial class AchiveMeeting : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Master.HolderMenu2 = "会议管理&nbsp;»&nbsp;会议归档";
            List<Model.Meeting> list = BusinessLogic.Meeting.ListMeetingByStaus(4);
            if (0 == list.Count)
            {
              
                Label1.Text = "暂无会议需要归档";
               
            }
            else
            {
                GridView1.DataSource = list;
                GridView1.DataBind();
            }
        }

        protected void btnFinish_Click(object sender, EventArgs e)
        {
            int meetingApplyFormID = int.Parse(((Button)sender).CommandArgument.ToString());
            Dictionary<int, int> meetingAndEquipmentIDAndCount = BusinessLogic.MeetingEquipment.GetMeetingEquipmentIDAndCount(meetingApplyFormID);
            foreach (var dic in meetingAndEquipmentIDAndCount)
            {
                BusinessLogic.MeetingEquipment.ReturnEquipmentCount(dic.Key, dic.Value);
            }
            BusinessLogic.Meeting.UpdateMeetingApplyFormStatus(meetingApplyFormID, 3);
            Response.Redirect("~/OfficeAdmin/AchiveMeeting.aspx");
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            int meetingApplyFormID = int.Parse(((LinkButton)sender).CommandArgument.ToString());
            Dictionary<int, int> meetingAndEquipmentIDAndCount = BusinessLogic.MeetingEquipment.GetMeetingEquipmentIDAndCount(meetingApplyFormID);
            foreach (var dic in meetingAndEquipmentIDAndCount)
            {
                BusinessLogic.MeetingEquipment.ReturnEquipmentCount(dic.Key, dic.Value);
            }
            BusinessLogic.Meeting.UpdateMeetingApplyFormStatus(meetingApplyFormID, 5);
            Response.Redirect("~/OfficeAdmin/AchiveMeeting.aspx");
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GridView1.PageIndex = e.NewPageIndex;
                gvDataBind();
                TextBox tb = (TextBox)GridView1.BottomPagerRow.FindControl("inPageNum");
                tb.Text = (GridView1.PageIndex + 1).ToString();
            }
            catch
            {
            }
        }

        private void gvDataBind()
        {
            List<Model.Meeting> list = BusinessLogic.Meeting.ListMeetingByStaus(4);

            this.GridView1.DataSource = list;
            this.GridView1.DataBind();
            //gvMeetingEquipmentArr.AddRange(BusinessLogic.Meeting.ListMeetingByStaus(2));


            //this.gvReject.DataSource = Manager.GetusecarapplyformStatus(3);
            //this.gvReject.DataBind();
        }
    }
}