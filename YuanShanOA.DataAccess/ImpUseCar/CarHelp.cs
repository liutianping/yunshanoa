using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YunShanOA.Model.UseCarModel;
using YunShanOA.DataAccess.Mapping;
using System.Data.Linq;

namespace YunShanOA.DataAccess.UseCar
{
    public class CarHelp : YunShanOA.IDAL.IUseCar.ICar
    {
        YunShanOADataContext db = new YunShanOADataContext();
        public int Count()
        {
            return db.Car.Count();
        }
        public car GetCarByid(int id)
        {
            Car car = (from cars in db.Car where cars.CarId == id select cars).FirstOrDefault();
            return FillRecord(car);
        }
        public car GetCarByLicenseNumber(string id)
        {
            Car car = (from cars in db.Car where cars.LicenseNumber == id select cars).FirstOrDefault();
            return FillRecord(car);
        }

        public List<car> GetCarList()
        {
            var Query = from cars in db.Car  select cars;
            List<car> result = new List<car>();
            foreach (var item in Query)
            {
                result.Add(FillRecord(item));
            }
            return result;
        }
 
        public List<car> GetCarlistByType(usecartype usecartype)
        {
            throw new NotImplementedException();
        }

        public int Save(car mycar)
        {
            Car u;
            bool found = false;

            if (mycar.CarId == -1)
            {
                // new record
                u = new Car();
                db.Car.InsertOnSubmit(u);
                found = true;
            }
            else
            {
                // existing record
                u = (from Mycar in db.Car where Mycar.CarId == mycar.CarId select Mycar).FirstOrDefault();
                if (u != null)
                {
                    found = true;
                    u.CarId = mycar.CarId;
                }
            }
            if (found)
            {
                u.Comment = mycar.Comment;
                u.Driver = mycar.Driver;
                u.DriverEmail = mycar.DriverEmail;
                u.LicenseNumber = mycar.LicenseNumber;
                u.LoadCapacity = mycar.LoadCapacity;
                u.ModelNumber = mycar.ModelNumber;
                u.SeatingNumber = mycar.seatingNumber;
                u.Status = mycar.Status;
                u.UseCarTypeID = mycar.Usecartype.UseCarTypeID;
                try
                {
                    db.SubmitChanges();
                }
                catch (ChangeConflictException)
                {
                    db.ChangeConflicts.ResolveAll(RefreshMode.OverwriteCurrentValues);
                    db.SubmitChanges();
                }
                return u.CarId;
            }
            else
                return -1;
        }
        /// <summary>
        /// 通过车得类型和车得状态获取车得列表
        /// </summary>
        /// <param name="type">车得类型</param>
        /// <param name="Status">车得状态</param>
        /// <returns></returns>
        public List<car> GetCarByTAndS(int typeID, int Status)
        {
            var Query = from cars in db.Car where cars.UseCarTypeID == typeID && cars.Status == Status select cars;
            List<car> result = new List<car>();
            foreach (var item in Query)
            {
                result.Add(FillRecord(item));
            }
            return result;
        }
        private static car FillRecord(Car i)
        {
            car Result = null;
            if (i != null)
            {
                Result = new car();
                Result.CarId = i.CarId;
                Result.Status = i.Status;
                Result.Driver = i.Driver;
                Result.DriverEmail = i.DriverEmail;
                Result.Comment = i.Comment;
                Result.LicenseNumber = i.LicenseNumber;
                Result.ModelNumber = i.LicenseNumber;
                Result.seatingNumber = i.SeatingNumber;
                Result.LoadCapacity = i.LoadCapacity;
                Result.Usecartype = new YunShanOA.DataAccess.UseCar.UsecarTypeHelp().GetUsecarType(i.UseCarTypeID);
            }
            return Result;
        }
    }
}
