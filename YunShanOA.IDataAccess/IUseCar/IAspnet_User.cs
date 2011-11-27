using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YunShanOA.Model.UseCarModel;
namespace YunShanOA.IDAL.IUseCar
{
    public interface IAspnet_User
    {
        aspnet_user GetAspnet_UsersById(Guid id);
        IList<aspnet_user> GetAspnet_UsersList();
    }
}
