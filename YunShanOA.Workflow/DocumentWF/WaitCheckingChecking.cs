using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;

namespace YunShanOA.Workflow.DocumentWF
{

    public sealed class WaitCheckingChecking<T> : NativeActivity<T>
    {
        public WaitCheckingChecking()
            : base()
        {
        }
        public string BookmarkName { get; set; }
        public OutArgument<T> Input { get; set; }

        protected override void Execute(NativeActivityContext context)
        {
            context.CreateBookmark(BookmarkName,
                new BookmarkCallback(this.Continue));//自动创建的时候执行
        }

        void Continue(NativeActivityContext context, Bookmark bookmark,
            object obj)
        {

            Input.Set(context, (T)obj);//恢复时候执行
        }

        protected override bool CanInduceIdle { get { return true; } }
    }
}


