using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YunShanOA.Model.UseCarModel;

namespace YunShanOA.IDAL.IUseCar
{
    public interface IUsecarApplyform
    {
        int Count();
        usecarapplyform GetusecarapplyformById(int id);
        List<usecarapplyform> GetusecarapplyformStatus(int Status);
        List<usecarapplyform> GetGetusecarapplyfromList();
        int Sava(usecarapplyform usecarapplyform);
        List<NeedRide> GetNeedRide(string userName);
    }
}
