using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YunShanOA.Common
{
    public class InstanceNotPersintException : System.Exception
    {
        public InstanceNotPersintException(string message)
            : base(message)
        { 
            message = "出现未知错误。系统已经自动记录，等待管理员审查。";
            BusinessLogic.Log.SaveLog(new Model.Log()
            {
                LogContext = Message,
                LogTime = System.DateTime.Now,
                userName = System.Web.HttpContext.Current.User.Identity.Name
            });
        }

        public InstanceNotPersintException()
        {
            BusinessLogic.Log.SaveLog(new Model.Log()
            {
                LogContext =  Message,
                LogTime = System.DateTime.Now,
                userName = System.Web.HttpContext.Current.User.Identity.Name
            });
        }
    }
}
