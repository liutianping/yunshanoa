using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;

using YunShanOA.Model.DocumentModel;
using YunShanOA.Common2;

namespace YunShanOA.Workflow.DocumentWF
{

    public sealed class SendMail : CodeActivity
    {
        // 定义一个字符串类型的活动输入参数
        public InArgument<string> Email { get; set; }
        public InArgument<DocumentApply> apply { get; set; }
        // 如果活动返回值，则从 CodeActivity<TResult>
        // 派生并从 Execute 方法返回该值。
        protected override void Execute(CodeActivityContext context)
        {
            List<string> EmailList = new List<string>();
            EmailList.Add(Email.Get(context).ToString());
            MailModel mailModel = new MailModel();

            if (apply.Get(context).Status == 2)
            {
                StringBuilder MailBody = new StringBuilder();
                MailBody.Append("你好，这里是云山OA文档起草审核，你的起草审核通过！！！");
                mailModel.MailBody = MailBody.ToString();
                // mailModel.MailBody
                mailModel.DisplayName = "文档审核部门";
                mailModel.MailSubject = "你的起草通过！！";
            }
            if (apply.Get(context).Status == 3)
            {
                StringBuilder MailBody = new StringBuilder();
                MailBody.Append("你好，这里是云山OA文档起草审核，你的起草审核不能通过，请重新起草！！！");
                mailModel.MailBody = MailBody.ToString();
                // mailModel.MailBody
                mailModel.DisplayName = "文档审核部门";
                mailModel.MailSubject = "你的起草审核不能通过！！";
            }
            if (apply.Get(context).Status == 4)
            {
                StringBuilder MailBody = new StringBuilder();
                MailBody.Append("你好，副局长审批成功，等待局长审批！！");
                mailModel.MailBody = MailBody.ToString();
                // mailModel.MailBody
                mailModel.DisplayName = "文档审批部门";
                mailModel.MailSubject = "副局长审批成功！！";
            }
            if (apply.Get(context).Status == 5)
            {
                StringBuilder MailBody = new StringBuilder();
                MailBody.Append("你好，副局长审批成功。！！");
                mailModel.MailBody = MailBody.ToString();
                // mailModel.MailBody
                mailModel.DisplayName = "文档审批部门";
                mailModel.MailSubject = "副局长审批成功！！";
            }

            if (apply.Get(context).Status == 6)
            {
                StringBuilder MailBody = new StringBuilder();
                MailBody.Append("你好，副局长审批不通过！！！");
                mailModel.MailBody = MailBody.ToString();
                // mailModel.MailBody
                mailModel.DisplayName = "文档审批部门";
                mailModel.MailSubject = "你的起草审批已经通过！！";
            }
            if (apply.Get(context).Status == 7)
            {
                StringBuilder MailBody = new StringBuilder();
                MailBody.Append("你好，局长审批通过！！！！");
                mailModel.MailBody = MailBody.ToString();
                // mailModel.MailBody
                mailModel.DisplayName = "文档审批部门";
                mailModel.MailSubject = "局长审批通过！！";
            }
            if (apply.Get(context).Status == 8)
            {
                StringBuilder MailBody = new StringBuilder();
                MailBody.Append("你好，局长审批不通过！！！！");
                mailModel.MailBody = MailBody.ToString();
                // mailModel.MailBody
                mailModel.DisplayName = "文档审批部门";
                mailModel.MailSubject = "局长审批不通过！！";
            }
            // 获取 Text 输入参数的运行时值
            YunShanOA.Common2.SendEmail2.SendEmailToUseCarUsers(EmailList, mailModel);
        }
    }
}

