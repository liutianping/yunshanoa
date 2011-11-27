using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;

namespace YunShanOA.Workflow.Meeting
{

    public sealed class ArrangementEquipment<T> : NativeActivity<T>
    {
        //书签名字
        public string BookmarkName { get; set; }

        //审核的结果 1同意 2审核中 3不同意
        public OutArgument<T> Input { get; set; }

        protected override void Execute(NativeActivityContext context)
        {
            context.CreateBookmark(BookmarkName, new BookmarkCallback(this.Continues));

        }
        //恢复书签时自动调用这个方法
        void Continues(NativeActivityContext context, Bookmark bookMark, object obj)
        {
            Input.Set(context, (T)obj);
        }

        protected override bool CanInduceIdle
        {
            get
            {
                return true;
            }
        }
    }
}
