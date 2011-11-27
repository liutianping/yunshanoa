using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YunShanOA.AJAX
{
    /// <summary>
    /// DeleteRole 的摘要说明
    /// </summary>
    public class DeleteRole : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
           string roleNameList=context.Request.QueryString["roleNameList"];
           if (!string.IsNullOrEmpty(roleNameList))
           {
               roleNameList = roleNameList.TrimStart(new char[] { '|' });
               string[] arrRoleName = roleNameList.Split(new char[] { '|' });
               context.Response.Write( RoleManagerOK2.DeleteRole(arrRoleName));
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