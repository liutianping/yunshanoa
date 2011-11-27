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

    public class UsecarAndUserManager
    {
        private static readonly IUsecarAndUser dal = YunShanOA.DALFactory.UseCarInstanceFactory.GetUsecarAndUserInstance();
        public int Count()
        {
            return dal.Count();
        }
        public usecaranduser GetUseCarAndUser(int id)
        {
            return dal.GetUseCarAndUser(id);
        }
        public List<usecaranduser> GetCarAndUserlistByFormID(int UseCarApplyFormID)
        {
            return dal.GetCarAndUserlistByFormID(UseCarApplyFormID);
        }
        public int Save(usecaranduser myusecaranduser)
        {
            if (myusecaranduser != null)
            {
                return dal.Save(myusecaranduser);
            }
            return -1;

        }

    }
}
