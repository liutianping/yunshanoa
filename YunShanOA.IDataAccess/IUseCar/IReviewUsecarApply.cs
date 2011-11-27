using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YunShanOA.Model.UseCarModel;

namespace YunShanOA.IDAL.IUseCar
{
    public interface IReviewUseCarApplyForm
    {
        int Cont();
        ReviewUseCarApplyForm GetReviewUseCarApplyFormByID(int id);
        ReviewUseCarApplyForm GetReviewUseCarApplyFormByReName(string name);
        ReviewUseCarApplyForm GetReviewUseCarApplyFormByUseCarApplyFormID(int id);
        IList<ReviewUseCarApplyForm> GetReviewUseCarApplyFormList();
        int Save(ReviewUseCarApplyForm ReviewUseCarApplyForm);

    }
}
