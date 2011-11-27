using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using YunShanOA.Model.DocumentModel;


namespace YunShanOA.Workflow.DocumentWF
{

    public sealed class CreateApply : CodeActivity
    {
        public InArgument<requestinfo> request { get; set; }
        public OutArgument<DocumentApply> Apply { get; set; }
        public OutArgument<string> Email { get; set; }
        protected override void Execute(CodeActivityContext context)
        {
            DocumentApply Applyinfo = new DocumentApply();
            Applyinfo.Author = request.Get(context).Author;
            Applyinfo.DocumentName = request.Get(context).DocumentName;
            Applyinfo.WFID = context.WorkflowInstanceId;
            Applyinfo.IsNeed = request.Get(context).IsNeed;
            Applyinfo.DocumentPath = request.Get(context).DocumentPath;
            Applyinfo.Status =1;
            BusinessLogic.DocumentManager.DocumentManager manager = new BusinessLogic.DocumentManager.DocumentManager();
            int i = manager.Save(Applyinfo);
            Applyinfo.DocumentID = i;
            
            Apply.Set(context, Applyinfo);


            Email.Set(context, request.Get(context).Email.ToString());
            // 获取 Text 输入参数的运行时值
        }
    }
}
