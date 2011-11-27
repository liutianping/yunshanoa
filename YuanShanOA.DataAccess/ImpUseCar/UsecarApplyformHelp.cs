using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YunShanOA.DataAccess.Mapping;
using YunShanOA.Model.UseCarModel;
using System.Data.Linq;


namespace YunShanOA.DataAccess.UseCar
{
    public class UsecarApplyformHelp : YunShanOA.IDAL.IUseCar.IUsecarApplyform
    {
        YunShanOADataContext db = new YunShanOADataContext();
        public int Count()
        {
            return db.UseCarApplyForm.Count();
        }

        public Model.UseCarModel.usecarapplyform GetusecarapplyformById(int id)
        {
            UseCarApplyForm UseCarApplyForm = (from UseCarApplyForms in db.UseCarApplyForm where UseCarApplyForms.UseCarApplyFormID == id select UseCarApplyForms).FirstOrDefault();
            return FillRecord(UseCarApplyForm);
        }
        public List<Model.UseCarModel.usecarapplyform> GetusecarapplyformStatus(int Status)
        {
            var result = from UseCarApplyForms in db.UseCarApplyForm where UseCarApplyForms.ApplyStatus == Status select UseCarApplyForms;
            List<usecarapplyform> mylist = new List<usecarapplyform>();
            foreach (var t in result)
            {
                usecarapplyform usecarapplyform = new usecarapplyform();

                usecarapplyform = FillRecord(t);
                mylist.Add(usecarapplyform);
            }
            return mylist;
        }
        public List<NeedRide> GetNeedRide(string userName)
        {
            var query = from UseCarApplyForms in db.UseCarApplyForm where UseCarApplyForms.ApplyStatus == 1 select UseCarApplyForms;

            List<NeedRide> result = new List<NeedRide>();
            foreach (var item in query)
            {
                NeedRide user = new NeedRide();

                foreach (var a in item.UseCarAndUser)
                {

                    if (a.Name.Trim() == userName.Trim())
                    {
                        user.applyID = item.UseCarApplyFormID.ToString();
                        user.BeginTime = item.BeginTime.ToString();
                        user.EndTime = item.EndTime.ToString();
                        user.StartDes = item.StartDestination;
                        user.EndDes = item.EndDestination;
                        user.Name = a.Name;
                        user.Email = a.Email;
                        result.Add(user);
                    }


                }


            }
            return result;


        }
        public List<Model.UseCarModel.usecarapplyform> GetGetusecarapplyfromList()
        {
            var result = from UseCarApplyForms in db.UseCarApplyForm select UseCarApplyForms;
            List<usecarapplyform> mylist = new List<usecarapplyform>();
            foreach (var t in result)
            {
                usecarapplyform usecarapplyform = new usecarapplyform();
                usecarapplyform = FillRecord(t);
                mylist.Add(usecarapplyform);
            }
            return mylist;
        }

        public int Sava(Model.UseCarModel.usecarapplyform myForm)
        {
            UseCarApplyForm u;
            bool found = false;

            if (myForm.UseCarApplyFormID == -1)
            {
                // new record
                u = new UseCarApplyForm();
                db.UseCarApplyForm.InsertOnSubmit(u);
                found = true;
            }
            else
            {
                // existing record
                u = (from myUseCarApplyForm in db.UseCarApplyForm where myUseCarApplyForm.UseCarApplyFormID == myForm.UseCarApplyFormID select myUseCarApplyForm).FirstOrDefault();
                if (u != null)
                {
                    found = true;
                    int id = (int)myForm.UseCarApplyFormID;
                    u.UseCarApplyFormID = id;
                }
            }
            if (found)
            {
                u.ApplyReason = myForm.ApplyReason;
                u.ApplyUserName = myForm.ApplyUserName;
                u.BeginTime = myForm.BeginTime;
                u.EndTime = myForm.EndTime;
                u.Comment = myForm.Comment;
                u.StartDestination = myForm.StartDestination;
                u.EndDestination = myForm.EndDestination;
                u.UseCarTypeID = myForm.usecartype.UseCarTypeID;
                u.ApplyStatus = myForm.ApplyStatus;
                u.WFID = myForm.WFID;
                try
                {

                    db.SubmitChanges();
                    foreach (usecaranduser usecaranduser in myForm.Usecaranduser)
                    {
                        usecaranduser user = new Model.UseCarModel.usecaranduser();
                        user.UseCarUserId = usecaranduser.UseCarUserId;
                        user.UseCarApplyFormID = u.UseCarApplyFormID;
                        user.Name = usecaranduser.Name;
                        user.Email = usecaranduser.Email;
                        new YunShanOA.DataAccess.UseCar.UsecarAndUserHelp().Save(user);
                    }
                    db.SubmitChanges();
                }
                catch (ChangeConflictException)
                {
                    db.ChangeConflicts.ResolveAll(RefreshMode.OverwriteCurrentValues);
                    db.SubmitChanges();
                }
                return u.UseCarApplyFormID;
            }
            else
                return -1;
        }
        private Model.UseCarModel.usecarapplyform FillRecord(UseCarApplyForm i)
        {
            usecarapplyform result = null;
            if (i != null)
            {
                result = new usecarapplyform();
                result.UseCarApplyFormID = i.UseCarApplyFormID;
                result.ApplyUserName = i.ApplyUserName;
                result.usecartype = new YunShanOA.DataAccess.UseCar.UsecarTypeHelp().GetUsecarType(i.UseCarTypeID);
                result.WFID = i.WFID;
                result.BeginTime = i.BeginTime;
                result.EndTime = i.EndTime;
                result.StartDestination = i.StartDestination;
                result.EndDestination = i.EndDestination;
                result.ApplyReason = i.ApplyReason;
                result.ApplyStatus = i.ApplyStatus;
                result.Comment = i.Comment;
                result.Usecaranduser = new YunShanOA.DataAccess.UseCar.UsecarAndUserHelp().GetCarAndUserlistByFormID(i.UseCarApplyFormID);
            }
            return result;
        }
    }
}
