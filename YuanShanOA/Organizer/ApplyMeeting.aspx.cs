using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using YunShanOA.BusinessLogic;
using System.Drawing;
using System.Web.Security;
using System.Collections;

namespace YunShanOA.Meeting
{
    public partial class ApplyMeeting : System.Web.UI.Page
    {
        Dictionary<int, int> d_EquipmentCount = null;
        Model.MeetingRoom mr = null;
        Model.Meeting r_MeetingApplyForm = null;
        Dictionary<string, string> MeetingUserEmail = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            

            Master.Holdermenu3 = "会议管理&nbsp;»&nbsp;会议申请";

            if (!Page.IsPostBack)
            {
                List<Model.MeetingEquipment> listMeetingEquipment = BusinessLogic.MeetingEquipment.GetAllMeetingequipment();
                gvMeetingEquipment.DataSource = listMeetingEquipment;
                gvMeetingEquipment.DataBind();
                //绑定邮箱
                List<Model.UserInfo> listMeetingUserEmailAndName = BusinessLogic.MeetingUser.GetUserEmailAndName();
                cblMeetingUser.DataSource = listMeetingUserEmailAndName;
                cblMeetingUser.DataTextField = "UserName";
                cblMeetingUser.DataValueField = "UserEmail";
                cblMeetingUser.DataBind();
                //绑定会议类型
                List<Model.MeetingType> listMeetingType = BusinessLogic.MeetingType.GetMeetingType();
                ddlMeetingTypeID.DataSource = listMeetingType;
                ddlMeetingTypeID.DataTextField = "MeetingTypeName";
                ddlMeetingTypeID.DataValueField = "MeetingTypeID";
                ddlMeetingTypeID.DataBind();
            }
        }

        private void GetApplyFormResutl()
        {
            r_MeetingApplyForm = new Model.Meeting();
            d_EquipmentCount = new Dictionary<int, int>();
            MeetingUserEmail = new Dictionary<string, string>();
            mr = new Model.MeetingRoom();
            //MeetingApplyFormInfo
            //r_MeetingApplyForm.ApplyUserName = Membership.GetUser().UserName;
            r_MeetingApplyForm.ApplyUserName = txtApplyUserName.Text;
            r_MeetingApplyForm.BeginTime = DateTime.Parse(txtBeginTime.Text);
            r_MeetingApplyForm.Comments = txtComment.Text;
            r_MeetingApplyForm.EndTime = DateTime.Parse(txtEndTime.Text);
            r_MeetingApplyForm.MeetingIntroduction = txtMeetingInst.Text;
            r_MeetingApplyForm.MeetingStatus = 2;
            r_MeetingApplyForm.MeetingTopic = txtMeetingTopic.Text;
            r_MeetingApplyForm.WFID = Guid.Empty;
            r_MeetingApplyForm.MeetingTypeID = int.Parse(this.ddlMeetingTypeID.SelectedValue);
            //Get EquipmentName and count
            foreach (GridViewRow item in gvMeetingEquipment.Rows)
            {
                if (item.RowType == DataControlRowType.DataRow)
                {
                    int rowDatakey = int.Parse(gvMeetingEquipment.DataKeys[item.DataItemIndex].Value.ToString());
                    int Meetingcount = int.Parse(((DropDownList)item.FindControl("ddlFreeCountList")).SelectedItem.ToString());
                    d_EquipmentCount.Add(rowDatakey, Meetingcount);
                }
            }
            //get MeetingUser
            foreach (ListItem item in cblMeetingUser.Items)
            {
                if (item.Selected == true)
                {
                    MeetingUserEmail.Add(item.Value, item.Text);
                }
            }
            //Get MeetingRoom
            mr.MeetingRoomID = Convert.ToInt32(Request.Form["radioMeetingRoom"].ToString());
        }
        private ListItem[] ddlItems(int max)
        {
            ListItem[] lis = new ListItem[max + 1];
            ListItem li = null;
            if (max <= 0)
            {
                li = new ListItem();
                li.Text = "0";
                lis[0] = li;
                return lis;
            }

            for (int i = 0; i < max; i++)
            {
                li = new ListItem();
                li.Text = i + "";
                lis[i] = li;
            }
            li = new ListItem();
            li.Text = max + "";
            lis[max] = li;
            return lis;
        }

        protected void btnApplyMeeting_Click1(object sender, EventArgs e)
        {

            GetApplyFormResutl();
            foreach (var dic in d_EquipmentCount)
            {
                BusinessLogic.MeetingEquipment.UpdateFreeCount(dic.Key, dic.Value);
            }

            Workflow.Meeting.MeetingApplyFlowProcess.CreateAndRun(r_MeetingApplyForm, d_EquipmentCount, MeetingUserEmail, mr);
            
           //Server.Transfer("~/Organizer/ApplyMeeting.aspx");
            //Response.Redirect("~/Organizer/ApplyMeeting.aspx");
            this.Response.Write("<script  language='javascript'>alert('申请成功，请等待审核...'); window.opener = ''; window.open('', \"_self\");window.close();window.open('ApplyMeeting.aspx','ss','width='+(screen.availWidth-15)+',height='+(screen.availHeight-120)+',top=0,left=0,toolbar=yes,menubar=yes,scrollbars=yes,resizable=yes,, location=yes, status=yes')</script>");
           
        }

        protected void gvMeetingEquipment_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void gvMeetingEquipment_RowDataBound1(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)//判断是否为数据行
            {
                DropDownList ddlMeetingFreeCount = e.Row.FindControl("ddlFreeCountList") as DropDownList;
                int max = int.Parse(e.Row.Cells[1].Text);
                ddlMeetingFreeCount.Items.AddRange(ddlItems(max));
            }
        }
    }
}