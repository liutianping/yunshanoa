using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using YunShanOA.Model.UseCarModel;

namespace YunShanOA.Workflow.UseCar
{

    public sealed class ArchiveUserCarApply : CodeActivity
    {
        public InArgument<usecarapplyform> UpdateApplyInfo { get; set; }
        protected override void Execute(CodeActivityContext context)
        {
            YunShanOA.BusinessLogic.UseCar.UsecarApplyformManager ApplyformManager = new BusinessLogic.UseCar.UsecarApplyformManager();
            usecarapplyform myform = UpdateApplyInfo.Get(context);
            myform.ApplyStatus = 5;
            ApplyformManager.Sava(myform);
        }
    }
}
