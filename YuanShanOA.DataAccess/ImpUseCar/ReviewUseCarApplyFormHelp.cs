using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YunShanOA.IDAL.IUseCar;
using YunShanOA.DataAccess.Mapping;
using System.Data.Linq;

namespace YunShanOA.DataAccess.UseCar
{
    public class ReviewUseCarApplyFormHelp : IReviewUseCarApplyForm
    {
        YunShanOADataContext db = new YunShanOADataContext();

        public int Cont()
        {
            throw new NotImplementedException();
        }

        public Model.UseCarModel.ReviewUseCarApplyForm GetReviewUseCarApplyFormByID(int id)
        {
            throw new NotImplementedException();
        }

        public Model.UseCarModel.ReviewUseCarApplyForm GetReviewUseCarApplyFormByReName(string name)
        {
            throw new NotImplementedException();
        }

        public Model.UseCarModel.ReviewUseCarApplyForm GetReviewUseCarApplyFormByUseCarApplyFormID(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Model.UseCarModel.ReviewUseCarApplyForm> GetReviewUseCarApplyFormList()
        {
            throw new NotImplementedException();
        }

        public int Save(Model.UseCarModel.ReviewUseCarApplyForm myReviewUseCarApplyForm)
        {

           YunShanOA.DataAccess.Mapping.ReviewUseCarApply  R;

            bool found = false;
            if (-1 ==myReviewUseCarApplyForm.ReviewUseCarApplyID)
            {
                R = new ReviewUseCarApply ();
                db.ReviewUseCarApply.InsertOnSubmit(R);
                found = true;
            }
            else
            {
                R = (from ReviewUseCarApplyForms in db.ReviewUseCarApply where ReviewUseCarApplyForms.ReviewUseCarApplyID == myReviewUseCarApplyForm.ReviewUseCarApplyID select ReviewUseCarApplyForms).FirstOrDefault();
                if (R != null)
                {
                    found = true;
                    int id = (int)myReviewUseCarApplyForm.ReviewUseCarApplyID;
                    R.ReviewUseCarApplyID = id;
                }
            }
            if (found)
            {
                R.ReviewUseCarApplyID = myReviewUseCarApplyForm.ReviewUseCarApplyID;
                R.ReviewUserName = myReviewUseCarApplyForm.ReviewUserName;
                R.UseCarApplyFormID = myReviewUseCarApplyForm.UseCarApplyFormID;
                R.Agree = myReviewUseCarApplyForm.Agree;
                try
                {
                    db.SubmitChanges();

                }
                catch (ChangeConflictException)
                {
                    db.ChangeConflicts.ResolveAll(RefreshMode.OverwriteCurrentValues);
                    db.SubmitChanges();
                }
                return R.ReviewUseCarApplyID;
            }
            else
            {
                return -1;
            }
        }
    }
}
