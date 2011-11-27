using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YunShanOA.Model.UseCarModel;

namespace YunShanOA.IDAL.IUseCar
{
    public interface IUsecarAndUser
    {
        int Count();
        usecaranduser GetUseCarAndUser(int id);
        List<usecaranduser> GetCarAndUserlistByFormID(int UseCarApplyFormID);
        int Save(usecaranduser myusecaranduser);
    }
}
