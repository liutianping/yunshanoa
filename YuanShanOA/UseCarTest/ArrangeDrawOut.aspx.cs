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
    public partial class ArrangeDrawOut : System.Web.UI.Page
    {
        protected ArrayList SelectedItems
        {
            get
            {
                return (ViewState["mySelectedItems"] != null) ? (ArrayList)ViewState["mySelectedItems"] : null;
            }
            set
            {
                ViewState["mySelectedItems"] = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Master.Holdermenu6 = "用车管理&nbsp;»&nbsp;用车安排";
            if (!Page.IsPostBack)
            {
                gvDateBind();
            }
        }
        private void gvDateBind()
        {
            UsecarApplyformManager Manager = new UsecarApplyformManager();
            gvSelectAll.DataSource = null;
            gvSelectAll.DataSource = Manager.GetusecarapplyformStatus(1);
            gvSelectAll.DataBind();
        }
        protected void gvCarInf_DataBinding(object sender, EventArgs e)
        {
            //在每一次重新绑定之前，CollectSelected方法从当前页收集选中项的情况比（比如下一个就是一个重新绑定）
            CollectSelected();
        }
        protected void CollectSelected()
        {
            // 从当前页收集选中项的情况
            ArrayList selectedItems = null;
            if (this.SelectedItems == null)
                selectedItems = new ArrayList();
            else
                selectedItems = this.SelectedItems;
            for (int i = 0; i < this.gvCarInf.Rows.Count; i++)
            {
                string id = this.gvCarInf.Rows[i].Cells[1].Text;
                CheckBox cb = this.gvCarInf.Rows[i].FindControl("CheckBox1") as CheckBox;
                if (selectedItems.Contains(id) && !cb.Checked)
                    selectedItems.Remove(id);
                if (!selectedItems.Contains(id) && cb.Checked)
                    selectedItems.Add(id);
            }
            this.SelectedItems = selectedItems;
        }
        protected void gvCarInf_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //这里的处理是为了会选上一页之前选中的情况
            if (e.Row.RowIndex > -1 && this.SelectedItems != null)
            {
                YunShanOA.Model.UseCarModel.car user = (YunShanOA.Model.UseCarModel.car)e.Row.DataItem;
                CheckBox cb = e.Row.FindControl("CheckBox1") as CheckBox;
                if (this.SelectedItems.Contains(user.CarId.ToString()))
                    cb.Checked = true;
                else
                    cb.Checked = false;
            }
        }
        protected void gvCarInf_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                Response.Buffer = true;
                Response.ExpiresAbsolute = System.DateTime.Now.AddSeconds(-1);
                Response.Expires = 0;
                Response.CacheControl = "no-cache";
                Response.AppendHeader("Pragma", "No-Cache");
                gvCarInf.PageIndex = e.NewPageIndex;
                BindGridView(int.Parse(Session["UseCarTypeID"].ToString()), 2);
                TextBox tb = (TextBox)gvCarInf.BottomPagerRow.FindControl("inPageNum");
                tb.Text = (gvCarInf.PageIndex + 1).ToString();
            }
            catch
            {
            }
        }
        protected void gvCarInf_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "go")
            {
                try
                {
                    TextBox tb = (TextBox)gvCarInf.BottomPagerRow.FindControl("inPageNum");
                    int num = Int32.Parse(tb.Text);
                    GridViewPageEventArgs ea = new GridViewPageEventArgs(num - 1);
                    gvCarInf_PageIndexChanging(null, ea);
                }
                catch
                {
                }
            }
        }
        protected void lbtArange_Click(object sender, EventArgs e)
        {
            ShowDetail(sender);
        }
        private void ShowDetail(object sender)
        {
            this.btnSubmit.Visible = true;
            string newid = ((LinkButton)sender).CommandArgument;
            usecarapplyform from = new UsecarApplyformManager().GetusecarapplyformById(int.Parse(newid));
            if (from.ApplyStatus == 4)
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
            this.lblType.Text = from.usecartype.UseCarTypeName.ToString();
            this.txtName.Text = from.ApplyUserName;
            this.txtWFID.Text = from.WFID.ToString();
            Session["UseCarTypeID"] = from.usecartype.UseCarTypeID;
            BindGridView(int.Parse(Session["UseCarTypeID"].ToString()), 2);
            this.txtMessage.Text = "尊敬的用车人员，你们所要求的车将在" + from.BeginTime.ToString() + "位于" + from.StartDestination + "出发!" + "你们的还车的时间是" + from.EndTime.ToString();
        }
        private void BindGridView(int TypeID, int Status)
        {
            //这里进行数据绑定
            CarManager Manager = new CarManager();
            this.gvCarInf.DataSource = null;
            this.gvCarInf.DataSource = Manager.GetCarByTAndS(TypeID, Status);
            this.gvCarInf.DataBind();
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ArrangeDrawOutFrom From = new ArrangeDrawOutFrom();
            From.Msg = this.txtMessage.Text.ToString();
            From.UseCarInfromID = this.lblApplyUseCarFromID.Text.ToString();
            From.WFID = Guid.Parse(this.txtWFID.Text.ToString());
            CollectSelected();
            List<string> carsID = new List<string>();
            foreach (object tmp in this.SelectedItems)
            {
                carsID.Add(tmp.ToString());
            }
            From.CarIDList = carsID;
            UseCarWorkFlowProcess.RunArrangeDrawOutFrom(From);
            this.lbMsg.Text = "安排成功，将以邮件的形式通知各位司机和用车人员";
            this.btnSubmit.Visible = false;
            BindGridView(int.Parse(Session["UseCarTypeID"].ToString ()), 2);
            gvDateBind();
            Session["UseCarTypeID"] = null;
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
    }
}