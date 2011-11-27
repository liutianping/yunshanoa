using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;


namespace YunShanOA.Meeting
{
    public partial class MeetingApplyProcess : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Master.Holdermenu1 = "会议管理&nbsp;»&nbsp;会议审批";
            this.pngDetailInfo.Visible = false;

           
            if (!Page.IsPostBack)
            {

                var query = BusinessLogic.Meeting.ListMeetingByStaus(2);
                if (query.Count == 0)
                {
                    lblMessage.Text = "暂无会议申请";
                    lblMessage.BackColor = System.Drawing.Color.Red;
                }
                else
                {
                    gvApplyInfo.DataSource = query;
                    gvApplyInfo.DataBind();
                }
            }
        }

        protected void gvApplyInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            pglVisibleTrue();
            lblWfID.Text = gvApplyInfo.Rows[gvApplyInfo.SelectedIndex].Cells[9].Text;
            txtApplyUserName.Text = gvApplyInfo.Rows[gvApplyInfo.SelectedIndex].Cells[1].Text;
            txtBeginTime.Text = gvApplyInfo.Rows[gvApplyInfo.SelectedIndex].Cells[5].Text;
            txtComment.Text = gvApplyInfo.Rows[gvApplyInfo.SelectedIndex].Cells[8].Text;
            txtEndTime.Text = gvApplyInfo.Rows[gvApplyInfo.SelectedIndex].Cells[6].Text;
            txtMeetingInst.Text = gvApplyInfo.Rows[gvApplyInfo.SelectedIndex].Cells[4].Text;
            txtMeetingTopic.Text = gvApplyInfo.Rows[gvApplyInfo.SelectedIndex].Cells[3].Text;
            //txtMeetingTypeID.Text = gvApplyInfo.Rows[gvApplyInfo.SelectedIndex].Cells[2].Text;

        }

        private void pglVisibleTrue()
        {
            if (pngDetailInfo.Visible == false)
                pngDetailInfo.Visible = true;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            YunShanOA.Model.Meeting meeting = new Model.Meeting();
            meeting.MeetingTopic = txtMeetingTopic.Text;
            meeting.MeetingIntroduction = txtMeetingInst.Text;
            meeting.MeetingTypeID = int.Parse(txtMeetingTypeID.Text);
            meeting.ApplyUserName = txtApplyUserName.Text;
            meeting.EndTime = DateTime.Parse(txtEndTime.Text);
            meeting.BeginTime = DateTime.Parse(txtBeginTime.Text);
            meeting.Comments = txtComment.Text;
            meeting.WFID = Guid.Parse(lblWfID.Text);
            if (RadioButton1.Checked)
            {
                meeting.MeetingStatus = 1;
            }
            else if (RadioButton2.Checked)
            {
                int meetingApplyFormID = BusinessLogic.Meeting.GetMeetingApplyFormIDByGUID(Guid.Parse(lblWfID.Text));
                meeting.MeetingStatus = 3;
                Dictionary<int, int> meetingIDAndName = BusinessLogic.MeetingEquipment.GetMeetingEquipmentIDAndCount(meetingApplyFormID);
                foreach (var m in meetingIDAndName)
                {
                    BusinessLogic.MeetingEquipment.ReturnEquipmentCount(m.Key, m.Value);
                }
                YunShanOA.Common.MailModel mailModel = new Common.MailModel();
                #region E-Mail Body
                System.Text.StringBuilder sbMailBody = new System.Text.StringBuilder();
                sbMailBody.Append("您好！");
                sbMailBody.Append("");
                sbMailBody.Append("您申请从");
                sbMailBody.Append(meeting.BeginTime);
                sbMailBody.Append("到");
                sbMailBody.Append(meeting.EndTime);
                sbMailBody.Append("召开“");
                sbMailBody.Append(meeting.MeetingTopic);
                sbMailBody.Append("”会议,未能通过审核。请检查您的申请，然后再重新申请。");
                #endregion
                mailModel.MailFrom = ConfigurationManager.AppSettings["commomEmail"].ToString();
                mailModel.Password = ConfigurationManager.AppSettings["emailPassword"].ToString();
                mailModel.SmtpServer = ConfigurationManager.AppSettings["smtpServer"].ToString();
                mailModel.SmtpPort = int.Parse(ConfigurationManager.AppSettings["port"].ToString());
                mailModel.DisplayName = "会议审核未通过";
                mailModel.MailBcc = null;
                mailModel.MailCc = null;
                mailModel.MailSubject = "会议审核未通过";
                mailModel.MailBody = sbMailBody.ToString();
                mailModel.MailTo = null;//此处留空，在SendEmail里才会赋值
                mailModel.SmtpPort = 25;
                mailModel.SmtpSsl = false;
                mailModel.UserName = ConfigurationManager.AppSettings["userName"].ToString();
                string userEmailByUserName = BusinessLogic.MeetingUser.GetUserEmailByUserName(BusinessLogic.Meeting.GetUserNameByApplyFormID(meetingApplyFormID));
                List<Model.UserInfo> listUserEmail = new List<Model.UserInfo>() {new Model.UserInfo(){UserEmail=userEmailByUserName} };
                YunShanOA.Common.SendEmail.SendEmailTo(listUserEmail, mailModel);
            }
            //todo 这里要用到用户名 登陆完成后要用真实的代替

            BusinessLogic.Meeting.UpdateReviewMeetingApplyState(BusinessLogic.Meeting.GetMeetingApplyFormIDByGUID(Guid.Parse(lblWfID.Text)), "", meeting.MeetingStatus);
            Workflow.Meeting.MeetingApplyFlowProcess.RunInstance(meeting);
            //Server.Transfer("~/Director_of_Eduction/MeetingApplyProcess.aspx?postback=y");
            //this.Response.Write("<script  language='javascript'>alert('审核成功！'); window.opener = ''; window.open('', \"_self\");window.close();window.open('MeetingApplyProcess.aspx','ss','width='+(screen.availWidth-15)+',height='+(screen.availHeight-120)+',top=0,left=0,toolbar=yes,menubar=yes,scrollbars=yes,resizable=yes,, location=yes, status=yes')</script>");
            this.script.Text = "<script  language='javascript'>alert('审核成功！'); </script>";
            
            
        }
        protected void gvApplyInfo_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[9].Style.Add("display", "none");
                e.Row.Cells[2].Style.Add("display", "none");
                e.Row.Cells[7].Style.Add("display", "none");
            }
        }

        private void gvDataBind()
        {
            var query = BusinessLogic.Meeting.ListMeetingByStaus(2);

            this.gvApplyInfo.DataSource = query;
            this.gvApplyInfo.DataBind();
            //gvApplyInfo.AddRange(BusinessLogic.Meeting.ListMeetingByStaus(2));
         

            //this.gvReject.DataSource = Manager.GetusecarapplyformStatus(3);
            //this.gvReject.DataBind();
        }
        protected void gvApplyInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gvApplyInfo.PageIndex = e.NewPageIndex;
                gvDataBind();
                TextBox tb = (TextBox)gvApplyInfo.BottomPagerRow.FindControl("inPageNum");
                tb.Text = (gvApplyInfo.PageIndex + 1).ToString();
            }
            catch
            {
            }
        }

        protected void gvApplyInfo_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "go")
            {
                try
                {
                    TextBox tb = (TextBox)gvApplyInfo.BottomPagerRow.FindControl("inPageNum");
                    int num = Int32.Parse(tb.Text);
                    GridViewPageEventArgs ea = new GridViewPageEventArgs(num - 1);
                    gvApplyInfo_PageIndexChanging(null, ea);
                }
                catch
                {
                }
            }
        }

      
    }
}