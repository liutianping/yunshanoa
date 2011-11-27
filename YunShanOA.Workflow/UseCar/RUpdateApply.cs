using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using YunShanOA.Model.UseCarModel;

namespace YunShanOA.Workflow.UseCar
{

    public sealed class RUpdateApply : CodeActivity
    {
        // 定义一个字符串类型的活动输入参数

        public InArgument<DateTime> BeginTime { get; set; }

        public InArgument<usecarapplyform> UpdateApplyInfo { get; set; }
        public InArgument<ReviewUseCarApplyForm> ReviewUseCarApplyForm { get; set; }
        public OutArgument<usecarapplyform> OUTApplyForm { get; set; }
        protected override void Execute(CodeActivityContext context)
        {
            YunShanOA.BusinessLogic.UseCar.UsecarApplyformManager ApplyformManager = new BusinessLogic.UseCar.UsecarApplyformManager();
            usecarapplyform myform = UpdateApplyInfo.Get(context);

            if (ReviewUseCarApplyForm.Get(context).Agree == 1)
            {
                myform.BeginTime = BeginTime.Get(context);
            }
            myform.ApplyStatus = 4;

            ApplyformManager.Sava(myform);
            OUTApplyForm.Set(context, myform);
        }
    }
}