using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using YunShanOA.Model.UseCarModel;
using YunShanOA.Common2;
using System.Configuration;
using YunShanOA.BusinessLogic.UseCar;

namespace YunShanOA.Workflow.UseCar
{

    public sealed class SendMail : CodeActivity
    {
        // 定义一个字符串类型的活动输入参数
        public InArgument<usecarapplyform> Apply { get; set; }
        // 如果活动返回值，则从 CodeActivity<TResult>
        // 派生并从 Execute 方法返回该值。
        protected override void Execute(CodeActivityContext context)
        {
  UsecarAndUserManager manager= new YunShanOA.BusinessLogic.UseCar.UsecarAndUserManager();
            // 获取 Text 输入参数的运行时值
            if (3 == Apply.Get(context).ApplyStatus)
            {
                StringBuilder MailBody = new StringBuilder();
                MailBody.Append("你好，这里是云山OA用车部门发布的信息，由");
                MailBody.Append(Apply.Get(context ).ApplyUserName .ToString()+"发布用车申请，由于各种原因不能通过，请仔细检查原因，重新申请，如果有问题乐意联系我们！！");
                MailModel mailModel = new MailModel();
                mailModel.MailBody = MailBody.ToString();
                   // mailModel.MailBody
                mailModel.DisplayName = "云山用车部门";
                mailModel.MailSubject = "用车申请不能通过！！";
                SendEmail2.SendEmailToUseCarUsers(manager.GetCarAndUserlistByFormID(Apply.Get(context).UseCarApplyFormID), mailModel);
            }
            if (1 == Apply.Get(context).ApplyStatus)
            {
                StringBuilder MailBody = new StringBuilder();
                MailBody.Append("你好，这里是云山OA用车部门发布的信息，由");
                MailBody.Append(Apply.Get(context).ApplyUserName.ToString() + "发布用车申请已经通过，开始时间是：");
                MailBody.Append(Apply.Get(context).BeginTime.ToString() + ",结束时间是：");
                MailBody.Append(Apply.Get(context).EndTime + ". 如果没有问题，请等待出车安排，如果有问题，请联系我们！！！");
                MailModel mailModel = new MailModel();
                mailModel.MailBody = MailBody.ToString();
                // mailModel.MailBody
                mailModel.DisplayName = "云山用车部门";
                mailModel.MailSubject = "用车申请通过！！";
                YunShanOA.Common2.SendEmail2.SendEmailToUseCarUsers(manager.GetCarAndUserlistByFormID(Apply.Get(context).UseCarApplyFormID), mailModel);
            }
            if (4== Apply.Get(context).ApplyStatus)
            {
                StringBuilder MailBody = new StringBuilder();
                MailBody.Append("你好，这里是云山OA用车部门发布的信息，由");
                MailBody.Append(Apply.Get(context).ApplyUserName.ToString() + "已近安排好，开始时间是：");
                MailBody.Append(Apply.Get(context).BeginTime.ToString() + ",结束时间是：");
                MailBody.Append(Apply.Get(context).EndTime + "司机将在："+Apply.Get(context) .StartDestination.ToString()+ "等候你们上车.，如果有问题，请联系我们！！！");
                MailModel mailModel = new MailModel();
                mailModel.MailBody = MailBody.ToString();
                // mailModel.MailBody
                mailModel.DisplayName = "云山用车部门";
                mailModel.MailSubject = "用车已近安排好了！！";
                YunShanOA.Common2.SendEmail2.SendEmailToUseCarUsers(manager.GetCarAndUserlistByFormID(Apply.Get(context).UseCarApplyFormID), mailModel);
            }
        }
    }
}
