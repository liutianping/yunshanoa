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

    public class Aspnet_UsersManage
    {
        private static readonly IAspnet_User dal = UseCarInstanceFactory.GetAspnet_UsersInstance();
        public aspnet_user GetAspnet_UsersById(Guid i)
        {
            return dal.GetAspnet_UsersById(i);
        }
        public IList<aspnet_user> GetAspnet_UsersList()
        {
            return dal.GetAspnet_UsersList();
        }

    }

}
