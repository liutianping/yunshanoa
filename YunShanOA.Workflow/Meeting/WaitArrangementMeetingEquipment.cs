using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;

namespace YunShanOA.Workflow.Meeting
{

    public sealed class WaitArrangementMeetingEquipment<T> : NativeActivity<T>
    {
        public string BookMarkName { get; set; }

        protected override void Execute(NativeActivityContext context)
        {
            context.CreateBookmark(BookMarkName,new BookmarkCallback(this.Continue));
        }

        void Continue(NativeActivityContext context, Bookmark bookMark, object obj)
        { 
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
