using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YunShanOA.IDAL.IUseCar;
using YunShanOA.DALFactory;
using YunShanOA.Model.UseCarModel;
using YunShanOA.BusinessLogic.UseCar;


namespace YunShanOA.BusinessLogic.UseCar
{
    public class ReviewUseCarApplyFormManager
    {
        private static readonly IReviewUseCarApplyForm dal = YunShanOA.DALFactory.UseCarInstanceFactory.GetReviewUsecarApplyInstance();
        public int Cont()
        {
          
            return dal.Cont();
        }

        public Model.UseCarModel.ReviewUseCarApplyForm GetReviewUseCarApplyFormByID(int id)
        {
            return dal.GetReviewUseCarApplyFormByID(id);
        }

        public Model.UseCarModel.ReviewUseCarApplyForm GetReviewUseCarApplyFormByReName(string name)
        {
            return GetReviewUseCarApplyFormByReName(name);
        }

        public Model.UseCarModel.ReviewUseCarApplyForm GetReviewUseCarApplyFormByUseCarApplyFormID(int id)
        {
            return dal.GetReviewUseCarApplyFormByUseCarApplyFormID(id);
        }

        public IList<Model.UseCarModel.ReviewUseCarApplyForm> GetReviewUseCarApplyFormList()
        {
            return dal.GetReviewUseCarApplyFormList();
        }

        public int Save(Model.UseCarModel.ReviewUseCarApplyForm ReviewUseCarApplyForm)
        {
            if (ReviewUseCarApplyForm != null)
            {
                return dal.Save(ReviewUseCarApplyForm);
            }
            return -1;
            
        }
    }
}
