using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace YunShanOA.AJAX
{
    /// <summary>
    /// ssss 的摘要说明
    /// </summary>
    public class ssss : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string roleName = context.Request.QueryString["roleName"];
            if (!string.IsNullOrEmpty(roleName))
            {
                if (!Roles.RoleExists(roleName))
                {
                    Roles.CreateRole(roleName);
                    context.Response.Write("创建角色成功！");
                }
                else
                {
                    context.Response.Write("角色名已经存在，请重新输入角色名。");
                }
            }
            else
            {
                context.Response.Write("角色名不能为空或全是空格！");
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