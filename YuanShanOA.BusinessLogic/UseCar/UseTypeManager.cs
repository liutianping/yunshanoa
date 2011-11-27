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
    public class UseTypeManager
    {
        private static readonly IUsecarType dal = YunShanOA.DALFactory.UseCarInstanceFactory.GetUsecarTypeInstance();
        public int Count()
        {
            return dal.Count();
        }
        public usecartype GetUsecarType(int id)
        {
            if (id < -1)
            {
                return null;
            }
            return dal.GetUsecarType(id);
        }
        public List<usecartype> GetUsecarTypeList()
        {
            return dal.GetUsecarTypeList();
        }
    }
}
