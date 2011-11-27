﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using YunShanOA.Model.DocumentModel;

namespace YunShanOA.Workflow.DocumentWF
{

    public sealed class UpdateAfterCheck : CodeActivity
    {
        // 定义一个字符串类型的活动输入参数
        public InArgument<ReviewCheck> ReviewChecks { get; set; }
        public InArgument<DocumentApply> inApply { get; set; }
        public OutArgument<DocumentApply> outApply { get; set; }
        // 如果活动返回值，则从 CodeActivity<TResult>
        // 派生并从 Execute 方法返回该值。
        protected override void Execute(CodeActivityContext context)
        {
            // 获取 Text 输入参数的运行时值
            ReviewCheck ReviewCheck = ReviewChecks.Get(context);
            DocumentApply documentApply = inApply.Get(context);
            if (ReviewCheck.Agree == 1)
            {

                if (inApply.Get(context).IsNeed)
                {
                    documentApply.Status = 4;
                }
                else
                {
                    documentApply.Status = 5;
                }
            }
            else
            {
                documentApply.Status = 6;
            }
            new YunShanOA.BusinessLogic.DocumentManager.DocumentManager().Save(documentApply);

            outApply.Set(context, documentApply);
        }
    }
}
