using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YunShanOA.DataAccess.Mapping;
using YunShanOA.Model.UseCarModel;


namespace YunShanOA.DataAccess.UseCar
{
    public class UsecarTypeHelp : YunShanOA.IDAL.IUseCar.IUsecarType
    {
        Mapping.YunShanOADataContext db = new YunShanOADataContext();
        public int Count()
        {
            return db.UseCarType.Count();
        }

        public Model.UseCarModel.usecartype GetUsecarType(int id)
        {
            UseCarType d = (from UseCarTypes in db.UseCarType where UseCarTypes.UseCarTypeID == id select UseCarTypes).FirstOrDefault();
            return FillRecord(d);
        }
        public List<usecartype> GetUsecarTypeList()
        {
            var query = from usecartypes in db.UseCarType select usecartypes;
            List<usecartype> result = new List<usecartype>();
            foreach (var t in query)
            {
                result.Add(FillRecord(t));
            }
            return result;
        }

        public int Save(Model.UseCarModel.usecartype usecartype)
        {
            throw new NotImplementedException();
        }

        private Model.UseCarModel.usecartype FillRecord(UseCarType d)
        {
            usecartype result = null;
            if (d != null)
            {
                result = new usecartype();
                result.UseCarTypeID = d.UseCarTypeID;
                result.UseCarTypeName = d.UseCarTypeName;
            }
            return result;
        }
    }
}
