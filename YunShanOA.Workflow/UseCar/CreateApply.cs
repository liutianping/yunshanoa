using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using YunShanOA.Model.UseCarModel;
using YunShanOA.BusinessLogic.UseCar;

namespace YunShanOA.Workflow.UseCar
{

    public sealed class CreateApply : CodeActivity
    {

        public InArgument<RequestForm> request { get; set; }
        public OutArgument<usecarapplyform> Apply { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            usecarapplyform Applyinfo = new usecarapplyform();
            Applyinfo.ApplyUserName = request.Get(context).ApplyUserName;
            Applyinfo.usecartype = new YunShanOA.BusinessLogic.UseCar.UseTypeManager().GetUsecarType(request.Get(context).usecartypeID);
            Applyinfo.WFID = context.WorkflowInstanceId;

            List<YunShanOA.Model.UseCarModel.usecaranduser> results = new List<usecaranduser>();
            foreach (usecaranduser user in request.Get(context).Usecaranduser)
            {
                usecaranduser usecaranduser = new usecaranduser();
                usecaranduser.Name = user.Name;
                usecaranduser.Email = user.Email;
                results.Add(usecaranduser);
            }
            Applyinfo.Usecaranduser = results;
            Applyinfo.BeginTime = request.Get(context).BeginTime;
            Applyinfo.EndTime = request.Get(context).EndTime;
            Applyinfo.StartDestination = request.Get(context).StartDestination;
            Applyinfo.EndDestination = request.Get(context).EndDestination;
            Applyinfo.ApplyStatus = 2;
            Applyinfo.ApplyReason = request.Get(context).ApplyReason;
            Applyinfo.Comment = request.Get(context).Comment;
            BusinessLogic.UseCar.UsecarApplyformManager ApplyformManager = new UsecarApplyformManager();
            int i = ApplyformManager.Sava(Applyinfo);
            List<usecaranduser> s = new List<usecaranduser>();
            s = new YunShanOA.BusinessLogic.UseCar.UsecarAndUserManager().GetCarAndUserlistByFormID(Applyinfo.UseCarApplyFormID);
            Applyinfo.Usecaranduser = s;
            Applyinfo.UseCarApplyFormID = i;
            Apply.Set(context, Applyinfo);
            // 获取 Text 输入参数的运行时值
        }
    }
}
