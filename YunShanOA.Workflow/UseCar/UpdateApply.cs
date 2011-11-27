using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using YunShanOA.BusinessLogic.UseCar;
using YunShanOA.Model.UseCarModel;


namespace YunShanOA.Workflow.UseCar
{

    public sealed class UpdateApply : CodeActivity
    {

        public InArgument<usecarapplyform> UpdateApplyInfo { get; set; }
        public InArgument<ReviewUseCarApplyForm> ReviewUseCarApplyForm { get; set; }
        public OutArgument<usecarapplyform> OUTApplyForm { get; set; }
        protected override void Execute(CodeActivityContext context)
        {
            YunShanOA.BusinessLogic.UseCar.UsecarApplyformManager ApplyformManager = new BusinessLogic.UseCar.UsecarApplyformManager();
            usecarapplyform myform = UpdateApplyInfo.Get(context);
            myform.ApplyStatus = ReviewUseCarApplyForm.Get(context).Agree;
            ApplyformManager.Sava(myform);
            new YunShanOA.BusinessLogic.UseCar.ReviewUseCarApplyFormManager().Save((YunShanOA.Model.UseCarModel.ReviewUseCarApplyForm)ReviewUseCarApplyForm.Get(context));
            OUTApplyForm.Set(context, myform);

        }
    }
}
