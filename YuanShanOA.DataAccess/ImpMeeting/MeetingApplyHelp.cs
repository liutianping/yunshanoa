using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using YunShanOA.IDAL.MeetingInterface;

namespace YunShanOA.DataAccess.ImpMeeting
{
    public class MeetingApplyHelp : IMeetingApply
    {
        private static readonly YunShanOA.DataAccess.Mapping.YunShanOADataContext dc = new Mapping.YunShanOADataContext();
        #region IMeetingApply 成员

        public List<Model.Meeting> ListMeetingByStatus(int status)
        {
            List<Model.Meeting> list = new List<Model.Meeting>();
            var query = from m in dc.MeetingApplyForm where m.MeetingStatus == status select m;

            foreach (var item in query)
            {
                list.Add(FillRecord(item));
            }
            return list;
        }

        public int SaveMeetingApply(Model.Meeting meetingAndApply)
        {
            throw new NotImplementedException();
        }

        public bool DeleteMeetingApply(Model.Meeting meetingAndApply)
        {
            throw new NotImplementedException();
        }

        public List<Model.Meeting> GetListMeetingApply()
        {
            throw new NotImplementedException();
        }

        public List<Model.Meeting> GetListMeetingApplyByStatus(int status)
        {
            List<Model.Meeting> list = new List<Model.Meeting>();
            var query = from m in dc.MeetingApplyForm where m.MeetingStatus == status select m;

            foreach (var item in query)
            {
                list.Add(FillRecord(item));
            }
            return list;
        }

        #endregion

        private YunShanOA.Model.Meeting FillRecord(YunShanOA.DataAccess.Mapping.MeetingApplyForm meetingapplyFrom)
        {
            Model.Meeting m = null;
            if (meetingapplyFrom != null)
            {
                m = new Model.Meeting();
                m.ApplyUserName = meetingapplyFrom.ApplyUserName;
                m.BeginTime = meetingapplyFrom.BeginTime;
                m.Comments = meetingapplyFrom.Comments;
                m.EndTime = meetingapplyFrom.EndTime;
                m.MeetingApplyFormID = meetingapplyFrom.MeetingApplyFormID;
                m.MeetingIntroduction = meetingapplyFrom.MeetingIntroduction;
                m.MeetingStatus = meetingapplyFrom.MeetingStatus;
                m.MeetingTopic = meetingapplyFrom.MeetingTopic;
                m.MeetingTypeID = meetingapplyFrom.MeetingTypeID;
                m.WFID = meetingapplyFrom.WFID;
            }
            return m;
        }


        #region IMeetingApply 成员


        public Guid GetGuidByApplyFormID(int applyFormID)
        {
            var q = (from m in dc.MeetingApplyForm
                     where applyFormID == m.MeetingApplyFormID
                     select m.WFID).First();
            return q;
        }

        #endregion

        #region IMeetingApply 成员


        public Model.Meeting GetApplyMeetingInfoByMeeingID(int meetingApplyFormID)
        {
            Model.Meeting meeting = null;
            var q = (from m in dc.MeetingApplyForm
                     where m.MeetingApplyFormID == meetingApplyFormID
                     select m).FirstOrDefault();
            if (null != q)
            {
                meeting = new Model.Meeting();
                meeting.ApplyUserName = q.ApplyUserName;
                meeting.BeginTime = q.BeginTime;
                meeting.EndTime = q.EndTime;
                meeting.MeetingTopic = q.MeetingTopic;
                meeting.MeetingIntroduction = q.MeetingIntroduction;
            }

            return meeting;
        }

        #endregion

        #region IMeetingApply 成员


        public void UpdateReviewMeetingApplyState(int meetingApplyFormID, string userName, int newState)
        {
            var query = dc.ReviewMeetingApply.Single(p => p.MeetingApplyFormID == meetingApplyFormID);
            query.ReviewUserName = userName;
            query.Agree = newState;
            dc.SubmitChanges();
        }

        #endregion

        #region IMeetingApply 成员


        public int GetMeetingApplyFormIDByGUID(Guid guid)
        {
            var query = (from p in dc.MeetingApplyForm
                         where p.WFID == guid
                         select p.MeetingApplyFormID).First();
            return query;
        }

        #endregion

        #region IMeetingApply 成员


        public string GetUserNameByApplyFormID(int meetingApplyFormID)
        {
            var query = (from p in dc.MeetingApplyForm
                         where p.MeetingApplyFormID == meetingApplyFormID
                         select p.ApplyUserName).First();
            return query;
        }

        #endregion

        #region IMeetingApply 成员


        public void UpdateMeetingApplyFormStatus(int meetingApplyFormID, int newStatus)
        {
            //var q = dc.MeetingApplyForm.Single(p => p.MeetingApplyFormID == meetingApplyFormID);
            //q.MeetingStatus = newStatus;
            //dc.SubmitChanges();
            dc.ExecuteCommand("UPDATE [dbo].[MeetingApplyForm] SET MeetingStatus=" + newStatus + " WHERE MeetingApplyFormID = @p0", meetingApplyFormID);
        }

        #endregion
    }
}
