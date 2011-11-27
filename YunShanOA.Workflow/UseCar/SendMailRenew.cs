using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using YunShanOA.Model.UseCarModel;
using YunShanOA.Common2;
using System.Configuration;

namespace YunShanOA.Workflow.UseCar
{

    public sealed class SendMailRenew : CodeActivity
    {
        // 定义一个字符串类型的活动输入参数
        public InArgument<ReviewUseCarApplyForm> ReviewUseCarApplyForm { get; set; }
        public InArgument<usecarapplyform> Apply { get; set; }
        // 如果活动返回值，则从 CodeActivity<TResult>
        // 派生并从 Execute 方法返回该值。
        protected override void Execute(CodeActivityContext context)
        {

            // 获取 Text 输入参数的运行时值
            if (2 == ReviewUseCarApplyForm.Get(context).Agree)
            {
                StringBuilder MailBody = new StringBuilder();
                MailBody.Append("你好，这里是云山OA用车部门发布的信息，由");
                MailBody.Append(Apply.Get(context).ApplyUserName.ToString() + "发布续车申请，由于各种原因不能通过，请仔细检查原因，重新申请，如果有问题乐意联系我们！！");
                MailModel mailModel = new MailModel();
                mailModel.MailBody = MailBody.ToString();
                // mailModel.MailBody
                mailModel.DisplayName = "云山用车部门";
                mailModel.MailSubject = "续车申请不能通过！！";
                YunShanOA.Common2.SendEmail2.SendEmailToUseCarUsers(new YunShanOA.BusinessLogic.UseCar.UsecarAndUserManager().GetCarAndUserlistByFormID(Apply.Get(context).UseCarApplyFormID), mailModel);
            }
            else
            {
                StringBuilder MailBody = new StringBuilder();
                MailBody.Append("你好，这里是云山OA用车部门发布的信息，由");
                MailBody.Append(Apply.Get(context).ApplyUserName.ToString() + "发布续车申请已经通过，开始时间是：");
                MailBody.Append(Apply.Get(context).BeginTime.ToString() + ",结束时间是：");
                MailBody.Append(Apply.Get(context).EndTime + "，如果有问题，请联系我们！！！");
                MailModel mailModel = new MailModel();
                mailModel.MailBody = MailBody.ToString();
                // mailModel.MailBody
                mailModel.DisplayName = "云山用车部门";
                mailModel.MailSubject = "续车申请通过！！";
                YunShanOA.Common2.SendEmail2.SendEmailToUseCarUsers(new YunShanOA.BusinessLogic.UseCar.UsecarAndUserManager().GetCarAndUserlistByFormID(Apply.Get(context).UseCarApplyFormID), mailModel);
            }

        }
    }
}
