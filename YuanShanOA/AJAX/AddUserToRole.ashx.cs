using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace YunShanOA.AJAX
{
    /// <summary>
    /// AddUserToRole 的摘要说明
    /// </summary>
    public class AddUserToRole : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string userName = context.Request.QueryString["userName"];
            if (!string.IsNullOrEmpty(userName))
            {
                context.Response.Write(RoleManagerOK2.GetChkBoxRoleByUserName(userName));
            }
            else
            {
                context.Response.Write("未选中用户名！");
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}