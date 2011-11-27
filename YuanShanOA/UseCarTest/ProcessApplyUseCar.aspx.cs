using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using YunShanOA.BusinessLogic.UseCar;
using YunShanOA.Model.UseCarModel;
using YunShanOA.Workflow.UseCar;

namespace YunShanOA.UseCarTest
{
    public partial class ProcessApplyUseCar : System.Web.UI.Page
    {
        private void ShowDetail(object sender)
        {
            string newid = ((LinkButton)sender).CommandArgument;
            RequestSelected();
            usecarapplyform usecarapplyform = new YunShanOA.BusinessLogic.UseCar.UsecarApplyformManager().GetusecarapplyformById((int.Parse(newid)));
            txtStartDes.Text = usecarapplyform.StartDestination.ToString();
            txtUseCarType.Text = usecarapplyform.usecartype.UseCarTypeName;
            txtStartTIme.Text = usecarapplyform.BeginTime.ToShortDateString();
            txtName.Text = usecarapplyform.ApplyUserName;
            txtApplyReason.Text = usecarapplyform.ApplyReason;
            this.lblQC.Text = usecarapplyform.WFID.ToString();
            txtApplyComment.Text = usecarapplyform.Comment;
            gvUsers.DataSource = usecarapplyform.Usecaranduser;
            this.LblID.Text = usecarapplyform.UseCarApplyFormID.ToString();
            txtEndDes.Text = usecarapplyform.EndDestination;
            txtEndTime.Text = usecarapplyform.EndTime.ToShortDateString();
            gvUsers.DataBind();
            Session["IDsdfsdf"] = usecarapplyform.ApplyStatus;
            this.lbMsg.Text = "";
            if (2 == usecarapplyform.ApplyStatus || 6 == usecarapplyform.ApplyStatus)
            {
                if (6 == usecarapplyform.ApplyStatus)
                {
                    this.lbMsg0.Visible = true;
                    this.lbMsg0.Text = "该 申 请 是 续 车 的 申 请！";
                    this.txtYName.Enabled = false;
                }
                else
                {
                    this.lbMsg0.Visible = false;
                    this.lbMsg0.Text = "";
                    this.txtYName.Enabled = true;
                }

                this.rbtOK.Checked = true;
                this.rbtOK.Enabled = true;
                this.rbtReject.Enabled = true;
                this.btnSubmit.Visible = true;

            }
            else
            {

                if (1 == usecarapplyform.ApplyStatus)
                {
                    this.rbtReject.Checked = false; ;
                    this.rbtOK.Checked = true;
                    this.lbMsg.Text = "你的请求已经被接受!";
                }
                else if (3 == usecarapplyform.ApplyStatus)
                {
                    this.rbtReject.Checked = true;
                    this.rbtOK.Checked = false;
                }
                this.rbtOK.Enabled = false;
                lbMsg0.Visible = false;
                this.rbtReject.Enabled = false;
                this.btnSubmit.Visible = false;
                this.lbMsg.Text = "你的请求已经被接受!";
                this.txtYName.Enabled = true;
            }
        }
        private void gvDataBind()
        {
            UsecarApplyformManager Manager = new UsecarApplyformManager();
            List<usecarapplyform> gvSelectAll = new List<usecarapplyform>();
            List<usecarapplyform> gvOK = new List<usecarapplyform>();
            gvSelectAll.AddRange(Manager.GetusecarapplyformStatus(2));
            gvSelectAll.AddRange(Manager.GetusecarapplyformStatus(6));

            this.gvSelectAll.DataSource = gvSelectAll;
            this.gvSelectAll.DataBind();

            gvOK.AddRange(Manager.GetusecarapplyformStatus(1));
            gvOK.AddRange(Manager.GetusecarapplyformStatus(4));
            gvOK.AddRange(Manager.GetusecarapplyformStatus(5));
            this.gvOK.DataSource = gvOK;
            this.gvOK.DataBind();

            this.gvReject.DataSource = Manager.GetusecarapplyformStatus(3);
            this.gvReject.DataBind();
        }
        private void RequestSelected()
        {
            if (pnlRequests.Visible.Equals(false))
            {
                pnlRequests.Visible = true;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Master.Holdermenu6 = "用车管理&nbsp;»&nbsp;续车审批";
            if (!Page.IsPostBack)
            {
                MultiView1.ActiveViewIndex = 0;
                gvDataBind();
            }
        }
        protected void lbtSelect_Click(object sender, EventArgs e)
        {
            ShowDetail(sender);
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ReviewUseCarApplyForm form = new ReviewUseCarApplyForm();
            if (rbtOK.Checked)
            {
                form.Agree = 1;
            }
            else
            {
                form.Agree = 3;
            }
            form.UseCarApplyFormID = int.Parse(this.LblID.Text.ToString());
            form.ReviewUserName = this.txtYName.Text.ToString();
            if (int.Parse(Session["IDsdfsdf"].ToString()) == 6)
            {

                UseCarWorkFlowProcess.RunRenewInstance(Guid.Parse(this.lblQC.Text.ToString()), form);
            }
            else
            {
                
                UseCarWorkFlowProcess.RunReviewApply(Guid.Parse(this.lblQC.Text.ToString()), form);
            }

            lbMsg.Text = "提交成功！";
            this.btnSubmit.Visible = false;
            gvDataBind();
            Session["IDsdfsdf"] = null;
        }
        protected void btn0_Click(object sender, EventArgs e)
        {
            this.pnlRequests.Visible = false;
            MultiView1.ActiveViewIndex = 0;
        }
        protected void btn1_Click(object sender, EventArgs e)
        {
            this.pnlRequests.Visible = false;
            MultiView1.ActiveViewIndex = 1;
        }
        protected void btn2_Click(object sender, EventArgs e)
        {
            this.pnlRequests.Visible = false;
            MultiView1.ActiveViewIndex = 2;

        }
        protected void gvSelectAll_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gvSelectAll.PageIndex = e.NewPageIndex;
                gvDataBind();
                TextBox tb = (TextBox)gvSelectAll.BottomPagerRow.FindControl("inPageNum");
                tb.Text = (gvSelectAll.PageIndex + 1).ToString();
            }
            catch
            {
            }
        }
        protected void gvSelectAll_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "go")
            {
                try
                {
                    TextBox tb = (TextBox)gvSelectAll.BottomPagerRow.FindControl("inPageNum");
                    int num = Int32.Parse(tb.Text);
                    GridViewPageEventArgs ea = new GridViewPageEventArgs(num - 1);
                    gvSelectAll_PageIndexChanging(null, ea);
                }
                catch
                {
                }
            }
        }
        protected void gvOK_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gvOK.PageIndex = e.NewPageIndex;
                gvDataBind();
                TextBox tb = (TextBox)gvSelectAll.BottomPagerRow.FindControl("inPageNum");
                tb.Text = (gvOK.PageIndex + 1).ToString();
            }
            catch
            {
            }
        }
        protected void gvOK_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "go")
            {
                try
                {
                    TextBox tb = (TextBox)gvOK.BottomPagerRow.FindControl("inPageNum");
                    int num = Int32.Parse(tb.Text);
                    GridViewPageEventArgs ea = new GridViewPageEventArgs(num - 1);
                    gvOK_PageIndexChanging(null, ea);
                }
                catch
                {
                }
            }
        }
        protected void gvReject_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gvReject.PageIndex = e.NewPageIndex;
                gvDataBind();
                TextBox tb = (TextBox)gvReject.BottomPagerRow.FindControl("inPageNum");
                tb.Text = (gvReject.PageIndex + 1).ToString();
            }
            catch
            {
            }
        }
        protected void gvReject_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "go")
            {
                try
                {
                    TextBox tb = (TextBox)gvReject.BottomPagerRow.FindControl("inPageNum");
                    int num = Int32.Parse(tb.Text);
                    GridViewPageEventArgs ea = new GridViewPageEventArgs(num - 1);
                    gvReject_PageIndexChanging(null, ea);
                }
                catch
                {
                }
            }
        }
    }
}