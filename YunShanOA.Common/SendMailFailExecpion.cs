using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YunShanOA.Common
{
   public class SendMailFailExecpion:System.Exception
    {
        SendMailFailExecpion(string errorMessage)
            : base(errorMessage)
        {
            errorMessage = "邮件发送失败！";
        }
    }
}
