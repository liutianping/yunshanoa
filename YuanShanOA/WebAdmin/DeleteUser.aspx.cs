using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace YunShanOA.WebAdmin
{
    public partial class DeleteUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

           MembershipUserCollection arrUser = Membership.GetAllUsers();
           this.GridView1.DataSource = arrUser;
           GridView1.DataBind();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string strID = GridView1.DataKeys[e.RowIndex].Value.ToString();
            if (!Membership.DeleteUser(strID, false))
                Response.Redirect("~/WebAdmin/DeleteUser.aspx");
            
        }
    }
}