using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YunShanOA.DataAccess.Mapping;
using YunShanOA.Model.UseCarModel;

namespace YunShanOA.DataAccess.UseCar
{
    public class aspnet_UsersHelp : YunShanOA.IDAL.IUseCar.IAspnet_User
    {
        YunShanOADataContext db = new YunShanOADataContext();
        public Model.UseCarModel.aspnet_user GetAspnet_UsersById(Guid id)
        {
            aspnet_Users aspnet_Users = (from aspnet_User in db.aspnet_Users where aspnet_User.UserId == id select aspnet_User).FirstOrDefault();
            return FillRecord(aspnet_Users);
        }
        public IList<aspnet_user> GetAspnet_UsersList()
        {
            var query = from aspnet_User in db.aspnet_Users select aspnet_User;
            IList<aspnet_user> result = new List<aspnet_user>();
            foreach (var t in query)
            {
                result.Add(FillRecord(t));
            }
            return result;
        }

        private Model.UseCarModel.aspnet_user FillRecord(aspnet_Users i)
        {
            aspnet_user aspnet_user = null;

            if (i != null)
            {
                aspnet_user = new Model.UseCarModel.aspnet_user();
           //     aspnet_user.UserID = i.UserId;
                aspnet_user.Name = i.UserName;
                aspnet_user.Email = i.aspnet_Membership.Email;
            }
            return aspnet_user;
        }
    }
}
