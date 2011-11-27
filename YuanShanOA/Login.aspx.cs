using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace YuanShanOA.Login
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginButton_Click1(object sender, EventArgs e)
        {
            //string yzm = ((TextBox)lgn.FindControl("txtYzm")).Text;
            //if (yzm.ToUpper().Equals(Session["code"].ToString().ToUpper()))
            //{

            //}
            //else
            //{
            //    Response.Write("<script>javascript:alert('验证码错误！');</script>");
                
            //    Session["code"] = null;
            //    //Server.Transfer("~/login.aspx");
            //}

        }

        protected void lgn_LoggedIn(object sender, EventArgs e)
        {
            if (User.Identity.Name != null)
            {
                Response.Redirect("~/temp.aspx?roleid=" + this.hfdRoleID.Value);
            }
            else
            {

            }
        }

        protected void Login2_LoggedIn(object sender, EventArgs e)
        {
            if (User.Identity.Name != null)
            {
                Response.Redirect("~/temp.aspx?roleid=" + this.hfdRoleID.Value);
            }
            else
            {

            }
        }

        protected void Login2_Authenticate(object sender, AuthenticateEventArgs e)
        {
            e.Authenticated =true;
            //e.Authenticated = Membership.ValidateUser(lgn.UserName, lgn.Password);
        }
    }
}