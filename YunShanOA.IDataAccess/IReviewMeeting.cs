using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YunShanOA.IDataAccess
{
    public interface IReviewMeeting
    {
        IList<Model.Meeting> GetListReviewMeetingByUserName(string userName);
    }
}
