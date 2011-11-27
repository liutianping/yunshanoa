using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YunShanOA.Model;
using YunShanOA.Model.UseCarModel;

namespace YunShanOA.IDAL.IUseCar
{
    public interface IUsecarType
    {
        int Count();
        usecartype GetUsecarType(int id);
        List<usecartype> GetUsecarTypeList();
        int Save(usecartype usecartype);
    }
}
