using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YunShanOA.Model.UseCarModel;

namespace YunShanOA.IDAL.IUseCar
{
    public interface ICar
    {
        int Count();
    
        car GetCarByid(int id);
        /// <summary>
        /// 通过牌照获取车得信息
        /// </summary>
        /// <param name="id">牌照号码</param>
        /// <returns></returns>
        car GetCarByLicenseNumber(string id);
        /// <summary>
        /// 通过车得类型和车得状态获取车得列表
        /// </summary>
        /// <param name="type">车得类型</param>
        /// <param name="Status">车得状态</param>
        /// <returns></returns>
        List<car> GetCarByTAndS(int typeID, int Status);
        List<car> GetCarList();
        List<car> GetCarlistByType(usecartype usecartype);
        int Save(car mycar);
    }
}
