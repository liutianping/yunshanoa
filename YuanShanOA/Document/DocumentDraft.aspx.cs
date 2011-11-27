using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YunShanOA.BusinessLogic.DocumentManager;
using System.IO;
using YunShanOA.Workflow.DocumentWF;

namespace YunShanOA.Document
{
    public partial class DocumentDraft : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.txtEmail.Text = "470762378@qq.com";
                this.txtAuthors.Text = "谢元深";
                this.txtDes.Text = "这里填写简介和描述";
                this.txtDocumentName.Text = "这里写文档的名称";
                Binding();
                this.btnFileUpload.Enabled = true;
            }
        }

        private void Binding()
        {
            DocumentTemplateManager manager = new DocumentTemplateManager();
            this.gvDocumentTemplate.DataSource = manager.GetDocumentTemplate();
            this.gvDocumentTemplate.DataBind();
        }
        protected void gvDocumentTemplate_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gvDocumentTemplate.PageIndex = e.NewPageIndex;
                //这里要数据绑定
                Binding();
                TextBox tb = (TextBox)gvDocumentTemplate.BottomPagerRow.FindControl("inPageNum");
                tb.Text = (gvDocumentTemplate.PageIndex + 1).ToString();
            }
            catch
            {
            }
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
        protected void btnFileUpload_Click(object sender, EventArgs e)
        {
            Random objRand = new Random();
            System.DateTime date = DateTime.Now;
            //生成随机文件名
            string name = date.Year.ToString() + date.Month.ToString() + date.Day.ToString() + date.Hour.ToString() + date.Minute.ToString()

                + date.Second.ToString() + Convert.ToString(objRand.Next(99) * 97 + 100);



            Session["filepath"] = "/Document/Files/" + name
+ FileUpLoad1.FileName.ToString();
            if (FileUpLoad1.HasFile)
            {
                //判断文件是否小于10Mb
                if (FileUpLoad1.PostedFile.ContentLength < 10485760)
                {
                    try
                    {

                        FileUpLoad1.PostedFile.SaveAs(Server.MapPath("~/Document/Files/")
   + name + FileUpLoad1.FileName);

                        //上传文件并指定上传目录的路径

                        /*注意->这里为什么不是:FileUpLoad1.PostedFile.FileName
                        * 而是:FileUpLoad1.FileName?
                        * 前者是获得客户端完整限定(客户端完整路径)名称
                        * 后者FileUpLoad1.FileName只获得文件名.
                        */

                        //当然上传语句也可以这样写(貌似废话):
                        //FileUpLoad1.SaveAs(@"D:\"+FileUpLoad1.FileName);

                        lblMessage.Text = "上传成功!";
                    }
                    catch
                    {
                        lblMessage.Text = "出现异常,无法上传!";
                        //lblMessage.Text += ex.Message;
                    }

                }
                else
                {
                    lblMessage.Text = "上传文件不能大于10MB!";
                }
            }
            else
            {
                lblMessage.Text = "";
            }
            YunShanOA.Workflow.DocumentWF.requestinfo requerst = new Workflow.DocumentWF.requestinfo();
            requerst.DocumentName = this.txtDocumentName.Text.ToString();
            requerst.Author = this.txtAuthors.Text.ToString();
            requerst.Email = this.txtEmail.Text.ToString();
            requerst.DocumentPath = Session["filepath"].ToString();
            if (this.DropDownList1.SelectedValue == "true")
            {
                requerst.IsNeed = true;
            }
            else
            {
                requerst.IsNeed = false;
            }
         
            DocumentWorkFlowProcess.CreateAndRun(requerst);
            this.lbMsg.Text = "起草成功，等待审核";
            this.btnFileUpload.Enabled = false;






        }





    }
}