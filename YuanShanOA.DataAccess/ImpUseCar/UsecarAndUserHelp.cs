using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YunShanOA.DataAccess.Mapping;
using YunShanOA.Model.UseCarModel;
using System.Data.Linq;

namespace YunShanOA.DataAccess.UseCar
{

    public class UsecarAndUserHelp : YunShanOA.IDAL.IUseCar.IUsecarAndUser
    {
        YunShanOADataContext db = new YunShanOADataContext();
        public int Count()
        {
            return db.UseCarAndUser.Count();
        }
        public usecaranduser GetUseCarAndUser(int id)
        {
            UseCarAndUser UseCarAndUser = (from UseCarAndUsers in db.UseCarAndUser where UseCarAndUsers.UseCarUserId == id select UseCarAndUsers).FirstOrDefault();
            return FillRecord(UseCarAndUser);
        }
        public List<usecaranduser> GetCarAndUserlistByFormID(int UseCarApplyFormID)
        {
            var query = from UseCarAndUsers in db.UseCarAndUser where UseCarAndUsers.UseCarApplyFormID == UseCarApplyFormID select UseCarAndUsers;
            List<usecaranduser> result = new List<usecaranduser>();
            foreach (var t in query)
            {
                result.Add(FillRecord(t));
            }
            return result;
        }
        public int Save(usecaranduser myusecaranduser)
        {
            UseCarAndUser u;
            bool found = false;
            if (-1 == myusecaranduser.UseCarUserId)
            {
                u = new UseCarAndUser();
                db.UseCarAndUser.InsertOnSubmit(u);
                found = true;
            }
            else
            {
                u = (from UseCarAndUsers in db.UseCarAndUser where UseCarAndUsers.UseCarUserId == myusecaranduser.UseCarUserId select UseCarAndUsers).FirstOrDefault();
                if (u != null)
                {
                    found = true;
                    int id = (int)myusecaranduser.UseCarUserId;
                    u.UseCarUserId = id;
                }
            }
            if (found)
            {
                u.UseCarUserId = myusecaranduser.UseCarUserId;
                u.UseCarApplyFormID = myusecaranduser.UseCarApplyFormID;
                u.Name = myusecaranduser.Name;
                u.Email = myusecaranduser.Email;
                try
                {
                    db.SubmitChanges();

                }
                catch (ChangeConflictException)
                {
                    db.ChangeConflicts.ResolveAll(RefreshMode.OverwriteCurrentValues);
                    db.SubmitChanges();
                }
                return u.UseCarUserId;
            }
            else
            {
                return -1;
            }
        }

        private usecaranduser FillRecord(UseCarAndUser i)
        {
            usecaranduser usecaranduser = null;
            if (i != null)
            {
                usecaranduser = new usecaranduser();
                usecaranduser.UseCarUserId = i.UseCarUserId;
                usecaranduser.UseCarApplyFormID = i.UseCarApplyFormID;
                usecaranduser.Name = i.Name;
                usecaranduser.Email = i.Email;
            }
            return usecaranduser;
        }
        public IList<usecaranduser> GetCarAndUserList()
        {
            throw new NotImplementedException();
        }
    }
}
