using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YunShanOA.IDataAccess;

namespace YunShanOA.DataAccess.ReviewMeeting
{
    public class ReviewMeeting : IReviewMeeting
    {
        YunShanOA.DataAccess.Mapping.YunShanOADataContext dc = new Mapping.YunShanOADataContext();
        public IList<Model.Meeting> GetListReviewMeetingByUserName(string userName)
        {
            IList<Model.Meeting> mr = null;
            var query = (from p in dc.MeetingApplyForm
                         join c in dc.ReviewMeetingApply on p.MeetingApplyFormID equals c.MeetingApplyFormID
                         where userName == c.ReviewUserName
                         select new
                         {
                             p.BeginTime,
                             p.EndTime,
                             p.MeetingTopic,
                             p.MeetingIntroduction,
                             p.Comments
                         }).ToList();
            if (null != query)
            {
                mr = (IList<Model.Meeting>)query.Select(t =>
                    new Model.Meeting {
                        Comments=t.Comments,
                        BeginTime=t.BeginTime,
                        EndTime=t.EndTime,
                        MeetingTopic=t.MeetingTopic,
                        MeetingIntroduction=t.MeetingIntroduction
                    }).ToList();
            }
            return mr;
        }
    }
}
