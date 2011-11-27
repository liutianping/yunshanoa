using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using YunShanOA.Model.DocumentModel;

namespace YunShanOA.Workflow.DocumentWF
{

    public sealed class UpdateDocumentApply : CodeActivity
    {
        // 定义一个字符串类型的活动输入参数
        public InArgument<ReviewQicao> Reviewqicao { get; set; }
        public InArgument<DocumentApply> inApply { get; set; }
        public OutArgument<DocumentApply> outApply { get; set; }
        // 如果活动返回值，则从 CodeActivity<TResult>
        // 派生并从 Execute 方法返回该值。
        protected override void Execute(CodeActivityContext context)
        {
            // 获取 Text 输入参数的运行时值
            ReviewQicao reviewQicao = Reviewqicao.Get(context);
            DocumentApply documentApply = inApply.Get(context);
            if (reviewQicao.Agree == 1)
            {
                documentApply.Status = 2;
            }
            else
            {
                documentApply.Status = 3;
            }
            new YunShanOA.BusinessLogic.DocumentManager.DocumentManager().Save(documentApply);
            outApply.Set(context, documentApply);
        }
    }
}
