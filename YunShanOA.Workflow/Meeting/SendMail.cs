using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;

namespace YunShanOA.Workflow.Meeting
{
    public class SendMail : CodeActivity
    {
        public InArgument<Dictionary<string,string>> UserEmail { get; set; }
        protected override void Execute(CodeActivityContext context)
        {
            Dictionary<string,string> getUserEmail = context.GetValue(UserEmail);
            //在这里获取下getUserEmail,看看有没有传进来数据
            //如果有数据，在这里就可以根据WFID来获取MeetingApplyFormID
            //如果没有的话，应该是数据在存储的时候丢失了，要另外想办法
        }
    }
}
