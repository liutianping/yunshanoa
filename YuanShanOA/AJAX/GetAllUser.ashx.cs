using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace YunShanOA.AJAX
{
    /// <summary>
    /// GetAllUser 的摘要说明
    /// </summary>
    public class GetAllUser : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.Write(RoleManagerOK2.GetAllUserNameList());
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