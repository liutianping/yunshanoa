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
    public partial class ApplyUseCar : System.Web.UI.Page
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
            Master.Holdermenu6 = "用车管理&nbsp;»&nbsp;用车申请";
            if (!Page.IsPostBack)
            {
                BindGridView();
                List<usecartype> TypeList = new YunShanOA.BusinessLogic.UseCar.UseTypeManager().GetUsecarTypeList();
                this.ddlCarType.DataSource = TypeList;
                ddlCarType.DataTextField = "UseCarTypeName";
                ddlCarType.DataValueField = "UseCarTypeID";
                ddlCarType.DataBind();
                this.ddlCarType.SelectedValue = "1";
                this.lblcarCount.Text = new CarManager().GetCarByTAndS(int.Parse(this.ddlCarType.SelectedValue), 2).Count().ToString();
                text();
            }
        }
        protected void gvUser_DataBinding(object sender, EventArgs e)
        {
            //在每一次重新绑定之前，CollectSelected方法从当前页收集选中项的情况比（比如下一个就是一个重新绑定）
            CollectSelected();
        }
        protected void gvUser_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //这里的处理是为了会选上一页之前选中的情况
            if (e.Row.RowIndex > -1 && this.SelectedItems != null)
            {
                YunShanOA.Model.UseCarModel.aspnet_user user = (YunShanOA.Model.UseCarModel.aspnet_user)e.Row.DataItem;
                CheckBox cb = e.Row.FindControl("CheckBox1") as CheckBox;
                if (this.SelectedItems.Contains((user.Name.ToString() + "|" + user.Email.ToString()).Trim()))
                    cb.Checked = true;
                else
                    cb.Checked = false;
            }
        }
        private void BindGridView()
        {
            //这里进行数据绑定
            Aspnet_UsersManage Manager = new Aspnet_UsersManage();
            this.gvUser.DataSource = Manager.GetAspnet_UsersList();
            this.gvUser.DataBind();

        }
        protected void CollectSelected()
        {
            // 从当前页收集选中项的情况
            ArrayList selectedItems = null;
            if (this.SelectedItems == null)
                selectedItems = new ArrayList();
            else
                selectedItems = this.SelectedItems;
            for (int i = 0; i < this.gvUser.Rows.Count; i++)
            {
                string id = this.gvUser.Rows[i].Cells[1].Text;
                CheckBox cb = this.gvUser.Rows[i].FindControl("CheckBox1") as CheckBox;
                if (selectedItems.Contains(id + "|" + this.gvUser.Rows[i].Cells[2].Text.ToString()) && !cb.Checked)
                    selectedItems.Remove(id + "|" + this.gvUser.Rows[i].Cells[2].Text.ToString());
                if (!selectedItems.Contains(id + "|" + this.gvUser.Rows[i].Cells[2].Text.ToString()) && cb.Checked)
                    selectedItems.Add(id + "|" + this.gvUser.Rows[i].Cells[2].Text.ToString());
            }
            this.SelectedItems = selectedItems;
        }
        private List<usecaranduser> CollectUser()
        {
            List<YunShanOA.Model.UseCarModel.usecaranduser> users = new List<Model.UseCarModel.usecaranduser>();
           
            foreach (object tmp in this.SelectedItems)
            {
                YunShanOA.Model.UseCarModel.usecaranduser user = new YunShanOA.Model.UseCarModel.usecaranduser();

                string[] s = tmp.ToString().Split('|');
                user.Name = s[0];
                user.Email = s[1];
                users.Add(user);
            }
            return users;

        }
        protected void gvUser_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gvUser.PageIndex = e.NewPageIndex;
                BindGridView();
                TextBox tb = (TextBox)gvUser.BottomPagerRow.FindControl("inPageNum");
                tb.Text = (gvUser.PageIndex + 1).ToString();
            }
            catch
            {
            }
        }
        protected void gvUser_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "go")
            {
                try
                {
                    TextBox tb = (TextBox)gvUser.BottomPagerRow.FindControl("inPageNum");
                    int num = Int32.Parse(tb.Text);
                    GridViewPageEventArgs ea = new GridViewPageEventArgs(num - 1);
                    gvUser_PageIndexChanging(null, ea);
                }
                catch
                {
                }
            }
        }
        protected void BtnApply_Click(object sender, EventArgs e)
        {

            CollectSelected();
            
            RequestForm requserform = new RequestForm();
            requserform.ApplyReason = txtApplyReason.Text.ToString();
            requserform.ApplyUserName = txtName.Text.ToString();
            requserform.BeginTime = DateTime.Parse(txtBeginTime.Text.ToString());
            requserform.EndTime = DateTime.Parse(txtEndTime.Text.ToString());
            requserform.StartDestination = txtStartDes.Text.ToString();
            requserform.EndDestination = txtEndDes.Text.ToString();
            requserform.Comment = txtComment.Text.ToString();
            requserform.usecartypeID = int.Parse(ddlCarType.SelectedValue);
            requserform.Usecaranduser = CollectUser();
            UseCarWorkFlowProcess.CreateAndRun(requserform);
            lbMsg.Text = "申请成功，等待管理员审核...";
            BtnApply.Visible = false;
            BtnCause.Visible = false;
        }
       
        public void text()
        {
            this.txtApplyReason.Text = "这里填写的是申请的理由";
            this.txtComment.Text = "这里填写的是申请的备注";
            this.txtName.Text = "谢元深";
            this.txtStartDes.Text = "开始位置";
            this.txtEndDes.Text = "结束位置";
            this.txtBeginTime.Text = DateTime.Now.ToString();
            this.txtEndTime.Text = DateTime.Now.ToString();
            this.txtComment.Text = "填写你的备注";
        }
        protected void ddlCarType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.lblcarCount.Text = new CarManager().GetCarByTAndS(int.Parse(this.ddlCarType.SelectedValue), 2).Count().ToString();
        }
    }
}