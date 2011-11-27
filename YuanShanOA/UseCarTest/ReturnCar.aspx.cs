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
    public partial class ReturnCar : System.Web.UI.Page
    {
        protected void lbtArange_Click(object sender, EventArgs e)
        {
            ShowDetail(sender);
        }
        private void ShowDetail(object sender)
        {
            this.btnSubmit.Visible = true;
            string newid = ((LinkButton)sender).CommandArgument;
            usecarapplyform from = new UsecarApplyformManager().GetusecarapplyformById(int.Parse(newid));
            if (from.ApplyStatus == 5)
            {
                this.lbMsg.Text = "你的请求已经被接受，请等待电脑处理!";
                this.btnSubmit.Visible = false;
            }
            else
            {
                this.btnSubmit.Visible = true;
                this.lbMsg.Text = "";
            }
            this.pnlRequests.Visible = true;
            this.lblApplyUseCarFromID.Text = from.UseCarApplyFormID.ToString();
            this.txtCarType.Text = from.usecartype.UseCarTypeName.ToString();
            this.txtName.Text = from.ApplyUserName;
            this.txtWFID.Text = from.WFID.ToString();
            this.txtUserCountt.Text= from.Usecaranduser.Count().ToString();
            this.txtID.Text = from.UseCarApplyFormID.ToString();
            this.txtBeginTime.Text = from.BeginTime.ToString();
            this.txtEndtime.Text = from.EndTime.ToString();
            this.txtStartDes.Text = from.StartDestination;
            this.txtEndDes.Text = from.EndDestination;
        }
        private void gvDateBind()
        {
            UsecarApplyformManager Manager = new UsecarApplyformManager();
            gvSelectAll.DataSource = Manager.GetusecarapplyformStatus(4);
            gvSelectAll.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Master.Holdermenu6 = "用车管理&nbsp;»&nbsp;用车还车";
            if (!Page.IsPostBack)
            {
                gvDateBind();
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            RenewForm form = new RenewForm();
            form.IsRenew = false;
            UseCarWorkFlowProcess.RunArrangeReturnCar(Guid.Parse(this.txtWFID.Text.ToString()), form);
            gvDateBind();
            this.lbMsg.Text = "提交成功";
            this.btnSubmit.Visible = false;

        }
        protected void gvSelectAll_PageIndexChanging1(object sender, GridViewPageEventArgs e)
        {
            this.pnlRequests.Visible = false;
            try
            {
                gvSelectAll.PageIndex = e.NewPageIndex;
                gvDateBind();
                TextBox tb = (TextBox)gvSelectAll.BottomPagerRow.FindControl("inPageNum");
                tb.Text = (gvSelectAll.PageIndex + 1).ToString();
            }
            catch
            {
            }
        }
        protected void gvSelectAll_RowCommand1(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "go")
            {
                try
                {
                    TextBox tb = (TextBox)gvSelectAll.BottomPagerRow.FindControl("inPageNum");
                    int num = Int32.Parse(tb.Text);
                    GridViewPageEventArgs ea = new GridViewPageEventArgs(num - 1);
                    gvSelectAll_PageIndexChanging1(null, ea);
                }
                catch
                {
                }
            }
        }
    }
}