using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YunShanOA.AJAX
{
    /// <summary>
    /// RoleManagereByUserName 的摘要说明
    /// </summary>
    public class RoleManagereByUserName : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string roleName = context.Request.QueryString["roleName"];
            string userName = context.Request.QueryString["userName"];
            if (!string.IsNullOrEmpty(roleName) && !string.IsNullOrEmpty(userName))
                context.Response.Write(RoleManagerOK2.RoleRemoveOrAddUser(userName, roleName));
            else
                context.Response.Write("用户名或角色名未选择！");
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