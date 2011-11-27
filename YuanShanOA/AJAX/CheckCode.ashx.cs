using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.SessionState;

namespace YunShanOA.AJAX
{
    /// <summary>
    /// CheckCode 的摘要说明
    /// </summary>
    public class CheckCode : IHttpHandler,IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            string code = context.Request.QueryString["code"];
            int flag = 0;
            //object o=context.Session["code"];
            if (context.Session["code"] != null && code != null)
            {
                if (code.Trim().ToUpper() == context.Session["code"].ToString())
                {
                    flag = 1;
                }
            }
           
            //context.Response.ContentType = "text/plain";
            context.Response.Write(flag);
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