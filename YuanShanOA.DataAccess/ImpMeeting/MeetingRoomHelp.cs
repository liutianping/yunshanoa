using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YunShanOA.IDAL.MeetingInterface;
using YunShanOA.Model;
using System.Data.Linq;

namespace YunShanOA.DataAccess.ImpMeeting
{
    public class MeetingRoomHelp : IMeetingRoom
    {
        YunShanOA.DataAccess.Mapping.YunShanOADataContext dc = new Mapping.YunShanOADataContext();
        #region IMeetingRoom 成员

        public int SaveMeetingRoom(Model.MeetingRoom meetingRoom)
        {
            DataAccess.Mapping.MeetingRoom mr = null;
            bool find = false;

            if (meetingRoom.MeetingRoomID == -1)
            {
                mr = new Mapping.MeetingRoom();
                dc.MeetingRoom.InsertOnSubmit(mr);
                find = true;
            }
            else
            {
                mr = (from meeting in dc.MeetingRoom
                      where meeting.MeetingRoomID == meetingRoom.MeetingRoomID
                      select meeting).FirstOrDefault();
                if (mr != null)
                {
                    find = true;
                    mr.MeetingRoomID = meetingRoom.MeetingRoomID;
                }
            }

            if (find)
            {
                mr.MeetingRoomCapacity = meetingRoom.MeetingRoomCapacity;
                mr.MeetingRoomName = meetingRoom.MeetingRoomName;
                mr.MeetingRoomStatus = meetingRoom.MeetingRoomStatus;
                mr.MeetingTypeID = meetingRoom.MeetingTypeID;
                try
                {
                    dc.SubmitChanges();
                }
                catch (ChangeConflictException)
                {
                    dc.ChangeConflicts.ResolveAll(RefreshMode.OverwriteCurrentValues);
                    dc.SubmitChanges();
                }
                return mr.MeetingRoomID;
            }
            else
            {
                return -1;
            }

        }

        public bool DeleteMeetingRoom(Model.MeetingRoom meetingAndRoom)
        {
            YunShanOA.DataAccess.Mapping.MeetingRoom mr = null;
            mr = (from room in dc.MeetingRoom where room.MeetingRoomID == meetingAndRoom.MeetingRoomID select room).FirstOrDefault();
            if (mr != null)
            {
                try
                {
                    dc.MeetingRoom.DeleteOnSubmit(mr);
                    dc.SubmitChanges();
                }
                catch (ChangeConflictException)
                {
                    dc.ChangeConflicts.ResolveAll(RefreshMode.OverwriteCurrentValues);
                    dc.SubmitChanges();
                }
            }
            return mr != null;
        }

        public List<Model.MeetingRoom> GetListMeetingRoom()
        {
            var query = from room in dc.MeetingRoom select room;
            List<Model.MeetingRoom> result = new List<MeetingRoom>();
            foreach (var r in query)
            {
                result.Add(FillRecord(r));
            }
            return result;
        }

        public Model.MeetingRoom QueryMeetingRoomByName(string roomName)
        {
            var query = (from room in dc.MeetingRoom where room.MeetingRoomName == roomName select room).FirstOrDefault();
            return FillRecord(query);
        }

        public List<Model.MeetingRoom> GetListMeetingRoomByStatus(int status)
        {
            throw new NotImplementedException();
        }

        private YunShanOA.Model.MeetingRoom FillRecord(YunShanOA.DataAccess.Mapping.MeetingRoom mr)
        {
            YunShanOA.Model.MeetingRoom meetingType = null;
            if (mr != null)
            {
                meetingType = new MeetingRoom();
                meetingType.MeetingRoomID = mr.MeetingRoomID;
                meetingType.MeetingRoomName = mr.MeetingRoomName;
                meetingType.MeetingRoomStatus = mr.MeetingRoomStatus;
                meetingType.MeetingRoomCapacity = mr.MeetingRoomCapacity;
                meetingType.MeetingTypeID = mr.MeetingTypeID;
            }
            return meetingType;
        }

        public List<MeetingRoom> GetListMeetingRoomNotIn(DateTime beginTime, DateTime endTime)
        {
            List<Model.MeetingRoom> list = new List<Model.MeetingRoom>();
            //-------------------------SQL 语句 ------------------------------
            //SELECT meetingroom.MeetingRoomID from MeetingRoom
            //where MeetingRoomID not in(
            //select MeetingRoomID from MeetingAndRoom
            //join MeetingApplyForm on MeetingAndRoom.MeetingApplyFormID=MeetingApplyForm.MeetingApplyFormID
            //where 
            //'2011-08-10 14:20:14.000' Between BeginTime AND EndTIme
            //or
            //'2011-08-10 15:20:14.000' BETWEEN BeginTime  AND  EndTime
            //and MeetingStatus!=3
            //)
            /////////////////////////////////////////////////////////////////////////////////
            var query1 = from mrid in dc.MeetingAndRoom
                         join meetingApplyForm in dc.MeetingApplyForm
                         on mrid.MeetingApplyFormID equals meetingApplyForm.MeetingApplyFormID
                         where (beginTime >= meetingApplyForm.BeginTime && beginTime <= meetingApplyForm.EndTime) ||
                               (endTime >= meetingApplyForm.BeginTime && endTime <= meetingApplyForm.EndTime) ||
                               (meetingApplyForm.BeginTime >= beginTime && meetingApplyForm.BeginTime <= endTime) ||
                               (meetingApplyForm.EndTime >= beginTime && meetingApplyForm.EndTime <= endTime)&&
                               mrid.Status!=3
                         select mrid.MeetingRoomID;
            var q = from m in dc.MeetingRoom
                    where !query1.Contains(m.MeetingRoomID)
                    select m;
            foreach (var item in q)
            {
                list.Add(FillRecord(item));
            }
            return list;
        }

        #endregion

        #region IMeetingRoom 成员


        public List<Model.ArrMeetingEquipmentInfo> GetWillArrMeetingRoomList()
        {
            //select begintime,endTime,meetingroomname from MeetingApplyForm
            //join MeetingAndRoom on MeetingApplyForm.MeetingApplyFormID=MeetingAndRoom.MeetingApplyFormID
            //join MeetingRoom on MeetingAndRoom.MeetingRoomID=MeetingRoom.MeetingRoomID

            List<Model.ArrMeetingEquipmentInfo> result = new List<ArrMeetingEquipmentInfo>();
            var q = (from meetingApplyForm in dc.MeetingApplyForm
                     join meetingAndRoom in dc.MeetingAndRoom
                     on meetingApplyForm.MeetingApplyFormID equals meetingAndRoom.MeetingApplyFormID
                     join meetingRoom in dc.MeetingRoom
                     on meetingAndRoom.MeetingRoomID equals meetingRoom.MeetingRoomID
                     where meetingApplyForm.MeetingStatus == 1
                     select new
                     {
                         meetingRoom.MeetingRoomName,
                         meetingApplyForm.BeginTime,
                         meetingApplyForm.EndTime,
                         meetingAndRoom.MeetingAndRoomID,
                         meetingApplyForm.MeetingApplyFormID,
                         meetingRoom.MeetingRoomID
                     }).Distinct().ToList();
            result = q.Select(t =>
                new Model.ArrMeetingEquipmentInfo
                {
                    MeetingRoomName = t.MeetingRoomName,
                    BeginTime = t.BeginTime,
                    EndTime = t.EndTime,
                    MeetingAndRoomID = t.MeetingAndRoomID,
                    MeetingApplyFormID = t.MeetingApplyFormID,
                    MeetingRoomID = t.MeetingRoomID
                }).ToList();
            return result;
        }

        public int GetMeetingApplyFormIDByMeetingMeetingAndRoomID(int meetingAndRoomID)
        {
            var q = from e in dc.MeetingAndRoom where e.MeetingAndRoomID == meetingAndRoomID select e.MeetingApplyFormID;
            return q.First();
        }

        public string GetMeetingRoomNameByMeetingApplyFormID(int meetingApplyFormID)
        {

            try
            {
                var q = (from meetingroomName in dc.MeetingRoom
                         join mar in dc.MeetingAndRoom on meetingroomName.MeetingRoomID equals mar.MeetingRoomID
                         join maf in dc.MeetingApplyForm on mar.MeetingApplyFormID equals maf.MeetingApplyFormID
                         where maf.MeetingApplyFormID == meetingApplyFormID
                         select meetingroomName.MeetingRoomName).First();
                return q;
            }
            catch (Exception)
            {
                return null;
            }

        }

        public void UpdateMeetingAndRoomStatus(int meetingApplyFormID, int newStatus)
        {
            var q = dc.MeetingAndRoom.Single(p => p.MeetingApplyFormID == meetingApplyFormID);
            q.Status = newStatus;
            dc.SubmitChanges();
        }

        #endregion
    }
}
