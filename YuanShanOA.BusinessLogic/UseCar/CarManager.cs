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
    public class CarManager
    {
 
        private static readonly ICar dal = YunShanOA.DALFactory.UseCarInstanceFactory.GetCarInstance();
        public int Count()
        {
            return dal.Count();
        }
        public car GetCarByid(int id)
        {
            return dal.GetCarByid(id);
        }
        public List<car> GetCarList()
        {
            return dal.GetCarList();
        }
        public List<car> GetCarByTAndS(int typeID, int Status)
        {
            return dal.GetCarByTAndS(typeID, Status);
        }
        public IList<car> GetCarlistByType(usecartype usecartype)
        {
            if (usecartype != null)
            {
                return dal.GetCarlistByType(usecartype);
            }
            return null;
        }
        public int Save(car mycar)
        {
            if (mycar!=null)
            {
                return dal.Save(mycar);
            }
            return -1;
        }
    }
}
