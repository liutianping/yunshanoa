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

    public class UsecarApplyformManager
    {
        private static readonly IUsecarApplyform dal = YunShanOA.DALFactory.UseCarInstanceFactory.GetUsecarApplyformInstance();
        public int Count()
        {
            return dal.Count();
        }
        public Model.UseCarModel.usecarapplyform GetusecarapplyformById(int id)
        {
            return dal.GetusecarapplyformById(id);
            
        }
        public List<NeedRide> GetNeedRide(string userName)
        {
            return dal.GetNeedRide(userName);
        }
        public int Sava(Model.UseCarModel.usecarapplyform myForm)
        {
            int i = -1;
            if (myForm!=null)
            {
                i =   dal.Sava(myForm);
            }
            return i;
        }
        public List<Model.UseCarModel.usecarapplyform> GetusecarapplyformStatus(int Status)
        {
            return dal.GetusecarapplyformStatus(Status);
        }
    }
}
