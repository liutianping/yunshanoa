using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YunShanOA.AJAX
{
    /// <summary>
    /// GetAllRoleForDelete 的摘要说明
    /// </summary>
    public class GetAllRoleForDelete : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.Write(RoleManagerOK2.GetAllRole());
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