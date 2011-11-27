using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace YunShanOA
{
    public partial class Temp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //lblMsgRole.Text = "您的角色是 " + Roles.GetRolesForUser(Profile.UserName)[0];
            //string userName = "";
            //string roleName = Request.QueryString["roleName"];
            //if (Roles.GetRolesForUser(Page.User.Identity.Name)[0].Equals("Director_of_Eduction"))//
            //{
            //}
            //Response.Write(@"<script   language='javascript'>alert('注意:10秒钟后   页面将自动跳转到您的部门页面!');</script>");
            //if (Roles.GetRolesForUser(Page.User.Identity.Name)[0].Equals("Dept1"))
            //{
            //    Response.Write(@"<script   language='javascript'>setTimeout('',10000);</script>");
            //    Response.Write("<meta   http-equiv='refresh'   content='10;URL=./dept1.aspx'>");//
            //}
            //else
            //{
            //    Response.Write(@"<script   language='javascript'>setTimeout('',10000);</script>");
            //    Response.Write("<meta   http-equiv='refresh'   content='10;URL=./dept2.aspx'>");//
            //}
            //int roleID=int.TryParse(Request.QueryString["roleid"].ToString(),
            //todo  在这里可以更改登陆成功后要跳转的页面
            string roleID = Request.QueryString["roleId"];//登陆页面传过来的标识符
            string roleName = string.Empty;
            try
            {
                roleName = Roles.GetRolesForUser(Page.User.Identity.Name)[0];//根据当前用户名获取的角色名
            }
            catch (Exception)
            {
                Response.Write("<script>javascript:alert('此用户还未启用！请联系管理员！.')</script>");
                Server.Transfer("~/Login.aspx");
                //获取失败
            }
            
            if ("1" == roleID)//局长
            {
                if (roleName.Equals("Director_of_Eduction"))
                {
                    Response.Redirect("~/Director_of_Eduction/Default.aspx");
                    return;
                }
            }
            else if ("2" == roleID)//副局长
            {
                if (roleName.Equals("Under_Secretary_for_Education"))
                {
                    Response.Redirect("~/Under_Secretary_for_Education/Default.aspx");
                    return;
                }
            }
            else if ("3" == roleID)//办公人员
            {
                if (roleName.Equals("OfficeAdmin"))
                {
                    Response.Redirect("~/OfficeAdmin/Default.aspx");
                    return;
                }
                else if (roleName.Equals("Organizer"))
                {
                    Response.Redirect("~/Organizer/Default.aspx");
                }
            }
            else if ("4" == roleID)//教职人员
            {
                if (roleName.Equals("SchoolUser"))
                {
                    Response.Redirect("~/SchoolUser/Default.aspx");
                    return;
                }
            }
            else if ("5" == roleID)//网站管理员
            {

                if (roleName.Equals("WebAdmin"))
                {
                    Response.Redirect("~/WebAdmin/Default.aspx");
                    return;
                }
            }

            Response.Write("<script>javascript:alert('您还未选择角色或角色有误！请重新登陆.')</script>");
           Server.Transfer("~/Login.aspx");

        }
    }
}