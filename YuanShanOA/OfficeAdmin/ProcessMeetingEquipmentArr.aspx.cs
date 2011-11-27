using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using YunShanOA.Common;

namespace YunShanOA.OfficeAdmin
{
    public partial class ProcessMeetingEquipmentArr : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Master.HolderMenu2 = "会议管理&nbsp;»&nbsp;设备安排";

            this.divDetail.Visible = false;
            Label1.Visible = false;
            if (!Page.IsPostBack)
            {
                List<Model.ArrMeetingEquipmentInfo> list=BusinessLogic.MeetingRoom.GetWillArrMeetingRoomList();
                if (0 != list.Count)
                {
                    gvMeetingEquipmentArr.DataSource = list;
                    gvMeetingEquipmentArr.DataBind();
                }
                else
                {
                    Label1.Visible = true;
                    Label1.Text = "暂无设备需您安排！";
                    Label1.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        protected void gvMeetingEquipmentArr_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[4].Style.Add("display", "none");
            }
        }

        protected void gvMeetingEquipmentArr_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.divDetail.Visible == false)
                this.divDetail.Visible = true;
            //gvVisibleTrue();
            lblMeetingRoomName.Text = gvMeetingEquipmentArr.Rows[gvMeetingEquipmentArr.SelectedIndex].Cells[1].Text;
            lblBeginTime.Text = gvMeetingEquipmentArr.Rows[gvMeetingEquipmentArr.SelectedIndex].Cells[2].Text;
            lblEndTime.Text = gvMeetingEquipmentArr.Rows[gvMeetingEquipmentArr.SelectedIndex].Cells[3].Text;
           
            //MeetingAndRoomID,用来查找MeetingApplyFormID,然后通过MeetingApplyFormID到MeetingAndEquipment找MeetingEquipmentID
            //然后再找名字和申请数量。绑定到gvMeetingEquip
            int meetingAndRoomID =Convert.ToInt32(gvMeetingEquipmentArr.Rows[gvMeetingEquipmentArr.SelectedIndex].Cells[4].Text);
           
            int MeetingApplyFormID = BusinessLogic.MeetingRoom.GetMeetingApplyFormIDByMeetingMeetingAndRoomID(meetingAndRoomID);
            hfdMeetingApplyFormID.Value = MeetingApplyFormID.ToString();
            List<Model.ArrMeetingEquipmentInfo> listEquipmentNameAndCount = BusinessLogic.MeetingEquipment.GetListMeetingEquipmentByMeetingApplyFormID(MeetingApplyFormID);
            gvEquipment.DataSource = listEquipmentNameAndCount;
            DataBind();
        }

        private void gvVisibleTrue()
        {
            if (gvMeetingEquipmentArr.Visible == false)
                gvMeetingEquipmentArr.Visible = true;
        }

        protected void btnCommit_Click(object sender, EventArgs e)
        {
            Model.Log log = new Model.Log();
            
            int meetingApplyFormID = int.Parse(this.hfdMeetingApplyFormID.Value);
            Model.Meeting meeting = BusinessLogic.Meeting.GetApplyMeetingInfoByMeeingID(meetingApplyFormID);
            meeting.MeetingApplyFormID = meetingApplyFormID;
            meeting.WFID = BusinessLogic.Meeting.GetGuidByApplyForm(meetingApplyFormID);
            if (rbtAgree.Checked)
            {
                
                //同意
                meeting.MeetingStatus = 4;
                //todo  发送邮件给与会者
                MailModel mailModel = new MailModel();
                Model.Meeting me = BusinessLogic.Meeting.GetApplyMeetingInfoByMeeingID(meetingApplyFormID);
                List<Model.UserInfo> UserEmailAndName = BusinessLogic.MeetingUser.GetUserEmailAndNameByMeetingApplyFormID(meetingApplyFormID);
                #region E-Mail Body
                System.Text.StringBuilder sbMailBody = new System.Text.StringBuilder();
                sbMailBody.Append("您好！");
                sbMailBody.Append("");
                sbMailBody.Append("邀请您参加");
                sbMailBody.Append(meeting.BeginTime);
                sbMailBody.Append("到");
                sbMailBody.Append(meeting.EndTime);
                sbMailBody.Append("，在");
                sbMailBody.Append(BusinessLogic.MeetingRoom.GetMeetingRoomNameByMeetingApplyFormID(meetingApplyFormID));
                sbMailBody.Append("召开的会议。谢谢！如有事情耽搁，请与");
                sbMailBody.Append(BusinessLogic.MeetingUser.GetUserEmailAndNameByMeetingApplyFormID(meetingApplyFormID).ToArray()[0].UserEmail);
                sbMailBody.Append("这个Email联系。");
                #endregion
                mailModel.MailFrom = ConfigurationManager.AppSettings["commomEmail"].ToString();
                mailModel.Password = ConfigurationManager.AppSettings["emailPassword"].ToString();
                mailModel.SmtpServer = ConfigurationManager.AppSettings["smtpServer"].ToString();
                mailModel.SmtpPort = int.Parse(ConfigurationManager.AppSettings["port"].ToString());
                mailModel.DisplayName = "会议邀请";
                mailModel.MailBcc = null;
                mailModel.MailCc = null;
                mailModel.MailSubject = meeting.MeetingTopic;
                mailModel.MailBody = sbMailBody.ToString();
                mailModel.MailTo = null;//此处留空，在SendEmail里才会赋值
                mailModel.SmtpPort = 25;
                mailModel.SmtpSsl = false;
                mailModel.UserName = ConfigurationManager.AppSettings["userName"].ToString();
                try
                {
                    SendEmail.SendEmailTo(UserEmailAndName, mailModel);
                    lblMessage.Text = "会议设备安排成功！";
                }
                catch (YunShanOA.Common.SendMailFailExecpion sendMailFail)
                {
                    log = new Model.Log();
                    log.LogContext = sendMailFail.Message;
                    log.LogTime = System.DateTime.Now;
                    log.userName = Page.User.Identity.Name;
                    log.LogTypeID = "1";
                    BusinessLogic.Log.SaveLog(log);
                    lblMessage.Text = "发送邮件出现异常，请联系申请人重新申请！申请人Email："+BusinessLogic.MeetingUser.GetUserEmailByUserName(log.userName);
                }
                
            }
            else
            {
                //不同意
                meeting.MeetingStatus = 3;
                Dictionary<int, int> meetingIDAndName = BusinessLogic.MeetingEquipment.GetMeetingEquipmentIDAndCount(meetingApplyFormID);
                foreach (var m in meetingIDAndName)
                {
                    BusinessLogic.MeetingEquipment.ReturnEquipmentCount(m.Key, m.Value);
                }
            }
            //todo 更新MeetingAndRoom里的状态，有待测试
            lblMessage.Text = "会议设备处理成功";
            //更新MeetingAndRoom表里的状态
            BusinessLogic.MeetingRoom.UpdateMeetingAndRoomStatus(meetingApplyFormID, meeting.MeetingStatus);
            BusinessLogic.Meeting.UpdateMeetingApplyFormStatus(meetingApplyFormID, meeting.MeetingStatus);
            Server.Transfer("~/OfficeAdmin/ProcessMeetingEquipmentArr.aspx");
        }

        protected void gvEquipment_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.Header)
            //{
            //    e.Row.Cells[2].Style.Add("display", "none");
            //}
        }

        protected void gvMeetingEquipmentArr_PageIndexChanged(object sender, EventArgs e)
        {
           
        }

        protected void gvMeetingEquipmentArr_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "go")
            {
                try
                {
                    TextBox tb = (TextBox)gvMeetingEquipmentArr.BottomPagerRow.FindControl("inPageNum");
                    int num = Int32.Parse(tb.Text);
                    GridViewPageEventArgs ea = new GridViewPageEventArgs(num - 1);
                    gvMeetingEquipmentArr_PageIndexChanging(null, ea);
                }
                catch
                {
                }
            }
        }

        protected void gvMeetingEquipmentArr_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gvMeetingEquipmentArr.PageIndex = e.NewPageIndex;
                gvDataBind();
                TextBox tb = (TextBox)gvMeetingEquipmentArr.BottomPagerRow.FindControl("inPageNum");
                tb.Text = (gvMeetingEquipmentArr.PageIndex + 1).ToString();
            }
            catch
            {
            }
        }

        private void gvDataBind()
        {
            List<Model.ArrMeetingEquipmentInfo> list = BusinessLogic.MeetingRoom.GetWillArrMeetingRoomList();

            this.gvMeetingEquipmentArr.DataSource = list;
            this.gvMeetingEquipmentArr.DataBind();
            //gvMeetingEquipmentArr.AddRange(BusinessLogic.Meeting.ListMeetingByStaus(2));


            //this.gvReject.DataSource = Manager.GetusecarapplyformStatus(3);
            //this.gvReject.DataBind();
        }

        protected void gvMeetingEquipmentArr_PageIndexChanging1(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gvMeetingEquipmentArr.PageIndex = e.NewPageIndex;
                gvDataBind();
                TextBox tb = (TextBox)gvMeetingEquipmentArr.BottomPagerRow.FindControl("inPageNum");
                tb.Text = (gvMeetingEquipmentArr.PageIndex + 1).ToString();
            }
            catch
            {
            }
        }
    }
}