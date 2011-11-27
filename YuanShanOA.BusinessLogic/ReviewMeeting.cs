using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YunShanOA.BusinessLogic
{
    public class ReviewMeeting
    {
        public static IList<Model.Meeting> GetReviewMeetingList(string userName)
        {
            return DALFactory.ReviewMeetingInstanceFactory.GetReviewMeetingInstance().GetListReviewMeetingByUserName(userName);
        }
    }
}
