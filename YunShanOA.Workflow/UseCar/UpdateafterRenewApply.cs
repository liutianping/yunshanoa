using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using YunShanOA.Model.UseCarModel;

namespace YunShanOA.Workflow.UseCar
{

    public sealed class UpdateafterRenewApply:CodeActivity
    {
        // 定义一个字符串类型的活动输入参数

       
        public InArgument<RenewForm> RenewForm { get; set; }
        public InArgument<usecarapplyform> UpdateApplyInfo { get; set; }
        public OutArgument<usecarapplyform> OUTApplyForm { get; set; }
        protected override void Execute(CodeActivityContext context)
        {
            YunShanOA.BusinessLogic.UseCar.UsecarApplyformManager ApplyformManager = new BusinessLogic.UseCar.UsecarApplyformManager();
            usecarapplyform myform = UpdateApplyInfo.Get(context);
            myform.EndTime = RenewForm.Get(context).RenewCarTime;
            myform.ApplyStatus = 6;
            ApplyformManager.Sava(myform);
            OUTApplyForm.Set(context, myform);
        }
    }
}