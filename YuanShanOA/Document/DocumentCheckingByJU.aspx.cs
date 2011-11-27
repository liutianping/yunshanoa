using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using YunShanOA.Workflow.DocumentWF;
using System.Web.Security;
using YunShanOA.Model.DocumentModel;

namespace YunShanOA.Document
{
    public partial class DocumentCheckingByJU : System.Web.UI.Page
    {
        protected void lbtArange_Click(object sender, EventArgs e)
        {
            ShowDetail(sender);
        }
        private void ShowDetail(object sender)
        {

            this.pnlRequests.Visible = true;
            string newid = ((LinkButton)sender).CommandArgument;
            DocumentApply DocumentApply = new YunShanOA.BusinessLogic.DocumentManager.DocumentManager().getDocumentApplyByid(int.Parse(newid));
            if (DocumentApply.Status == 3)
            {
                this.lbMsg.Text = "你的请求已经提交，请等待电脑处理!";
                this.btnSubmit.Enabled = false;
            }
            else
            {
                this.lbMsg.Text = "";
                this.btnSubmit.Enabled = true;
            }
            this.txtWFID.Text = DocumentApply.WFID.ToString();
            this.pnlRequests.Visible = true;
            this.txtAuthor.Text = DocumentApply.Author;
            this.txtID.Text = DocumentApply.DocumentID.ToString();
            this.txtName.Text = DocumentApply.DocumentName;
        }
        private void gvDateBind()
        {
            MembershipUser user = Membership.GetUser();

                gvDocumentTemplate.DataSource = new YunShanOA.BusinessLogic.DocumentManager.DocumentManager().getListByStatus(4);
                gvDocumentTemplate.DataBind();
         
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                gvDateBind();
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            YunShanOA.Workflow.DocumentWF.ReviewCheckCheck info = new Workflow.DocumentWF.ReviewCheckCheck();
            if (rbtOK.Checked == true)
            {
                info.Agree = 1;
            }
            else
            {
                info.Agree = 2;
            }

            try
            {
                DocumentWorkFlowProcess.RunCheckCheck(Guid.Parse(this.txtWFID.Text.ToString()), info);
                this.btnSubmit.Enabled = false;
                lbMsg.Text = "提交成功！";
            }
            catch (Exception)
            {
                throw;
            }



        }
        protected void gvDocumentTemplate_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.pnlRequests.Visible = false;
            try
            {
                gvDocumentTemplate.PageIndex = e.NewPageIndex;
                gvDateBind();
                TextBox tb = (TextBox)gvDocumentTemplate.BottomPagerRow.FindControl("inPageNum");
                tb.Text = (gvDocumentTemplate.PageIndex + 1).ToString();
                lbMsg.Text = "提交成功！";
                gvDateBind();
              
            }
            catch
            {
            }
        }

        protected void lbDetails_Click(object sender, EventArgs e)
        {
            ShowDetail(sender);


        }
        protected void lbDownLoad_Click(object sender, EventArgs e)
        {
            string path = ((LinkButton)sender).CommandArgument;
            String[] name = path.Split('/');
            string Name = name[name.Count() - 1];
            string fileName = Name;//客户端保存的文件名
            string filePath = Server.MapPath(path);//路径
            FileInfo fileInfo = new FileInfo(filePath);
            Response.Clear();
            Response.ClearContent();
            Response.ClearHeaders();
            Response.AddHeader("Content-Disposition", "attachment;filename=" + fileName);
            Response.AddHeader("Content-Length", fileInfo.Length.ToString());
            Response.AddHeader("Content-Transfer-Encoding", "binary");
            Response.ContentType = "application/octet-stream";
            Response.ContentEncoding = System.Text.Encoding.GetEncoding("gb2312");
            Response.WriteFile(fileInfo.FullName);
            Response.Flush();
            Response.End();
        }
        protected void gvDocumentTemplate_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "go")
            {
                try
                {
                    TextBox tb = (TextBox)gvDocumentTemplate.BottomPagerRow.FindControl("inPageNum");
                    int num = Int32.Parse(tb.Text);
                    GridViewPageEventArgs ea = new GridViewPageEventArgs(num - 1);
                    gvDocumentTemplate_PageIndexChanging(null, ea);
                }
                catch
                {
                }
            }
        }
    }
}