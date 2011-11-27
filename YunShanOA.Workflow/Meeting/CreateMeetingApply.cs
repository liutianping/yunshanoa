using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using YunShanOA.DataAccess.Mapping;

namespace YunShanOA.Workflow.Meeting
{

    public sealed class CreateMeetingApply : CodeActivity
    {
        public InArgument<YunShanOA.Model.Meeting> AssignedTo { get; set; }
        public OutArgument<YunShanOA.DataAccess.Mapping.MeetingApplyForm> Apply { get; set; }
        public InArgument<Model.MeetingRoom> MeetingRoomNameAndID { get; set; }
        protected override void Execute(CodeActivityContext context)
        {
            MeetingApplyForm meetingApplyForm = new MeetingApplyForm();
            YunShanOA.DataAccess.Mapping.YunShanOADataContext dc = new YunShanOADataContext();
            meetingApplyForm.ApplyUserName = AssignedTo.Get(context).ApplyUserName;
            meetingApplyForm.BeginTime = AssignedTo.Get(context).BeginTime;
            meetingApplyForm.Comments = AssignedTo.Get(context).Comments;
            meetingApplyForm.EndTime = AssignedTo.Get(context).EndTime;
            meetingApplyForm.MeetingIntroduction = AssignedTo.Get(context).MeetingIntroduction;
            meetingApplyForm.MeetingStatus = 2;
            meetingApplyForm.MeetingTopic = AssignedTo.Get(context).MeetingTopic;
            meetingApplyForm.MeetingTypeID = AssignedTo.Get(context).MeetingTypeID;
            meetingApplyForm.WFID = context.WorkflowInstanceId;

            var query = from p in dc.Workflows where p.WFID == meetingApplyForm.WFID select p;
            if (0 == query.Count())
            {
                YunShanOA.DataAccess.Mapping.Workflows wf = new Workflows();
                wf.WFID = meetingApplyForm.WFID;
                wf.WFTID = Guid.NewGuid();
                dc.Workflows.InsertOnSubmit(wf);
            }

            var query1 = from p in dc.MeetingApplyForm where p.WFID == meetingApplyForm.WFID select p;
            if (0 == query1.Count())
            {
                dc.MeetingApplyForm.InsertOnSubmit(meetingApplyForm);//将数据插入到MeetingApplyForm表
                dc.SubmitChanges();//提交MeeingApplyForm的更改，以便下面根据WFID来查询MeetingApplyFormID
                var quer = from p in dc.MeetingApplyForm where p.WFID == meetingApplyForm.WFID select p;
                if (0 != quer.Count())
                {
                    Model.MeetingRoom mar = new Model.MeetingRoom();
                    mar = MeetingRoomNameAndID.Get(context);
                    int meetingApplyFormID = quer.First().MeetingApplyFormID;
                    DataAccess.Mapping.MeetingAndRoom m = new MeetingAndRoom();
                    m.Status = 2;
                    m.MeetingApplyFormID = meetingApplyFormID;
                    m.MeetingRoomID = mar.MeetingRoomID;
                    dc.MeetingAndRoom.InsertOnSubmit(m);
                    dc.SubmitChanges();
                }
            }
            Apply.Set(context, meetingApplyForm);

        }
    }
}
