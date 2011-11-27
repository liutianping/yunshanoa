using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YunShanOA.IDataAccess;
using YunShanOA.IDAL.MeetingInterface;

namespace YunShanOA.DataAccess.ImpMeeting
{
    public class MeetingEquipmentHelp : IMeetingEquipment
    {
        YunShanOA.DataAccess.Mapping.YunShanOADataContext dc = new Mapping.YunShanOADataContext();
        #region IMeetingEquipment 成员

        public int SaveMeetingEquipment(Model.MeetingEquipment meetingAndEquipment)
        {
            throw new NotImplementedException();
        }

        public bool DeleteMeetingEquipment(Model.MeetingEquipment meetingAndEquipment)
        {
            throw new NotImplementedException();
        }

        public List<Model.MeetingEquipment> GetListMeetingEquipment()
        {
            List<Model.MeetingEquipment> list = new List<Model.MeetingEquipment>();
            var query = from equipment in dc.MeetingEquipment select equipment;
            foreach (var item in query)
            {
                list.Add(FillRecord(item));
            }
            return list;
        }

        public Model.MeetingEquipment QueryMeetingEquipmentByName(string EquipmentName)
        {
            throw new NotImplementedException();
        }

        public List<Model.MeetingEquipment> GetListMeetingEquipmentByStatus(int status)
        {
            throw new NotImplementedException();
        }

        private Model.MeetingEquipment FillRecord(YunShanOA.DataAccess.Mapping.MeetingEquipment meetingEquipment)
        {
            Model.MeetingEquipment m = null;

            if (meetingEquipment != null)
            {
                m = new Model.MeetingEquipment();
                m.Comments = meetingEquipment.Comments;
                m.EquipmentDescription = meetingEquipment.EquipmentDescription;
                m.EquipmentName = meetingEquipment.EquipmentName;
                m.MeetingEquipmentCount = meetingEquipment.MeetingEquipmentCount;
                m.MeetingEquipmentFreeCount = meetingEquipment.MeetingEquipmentFreeCount;
                m.MeetingEquipmentID = meetingEquipment.MeetingEquipmentID;
                
                m.Status = meetingEquipment.Status;
            }
            return m;
        }

        public List<Model.ArrMeetingEquipmentInfo> GetEquipmentDetailListByMeetingApplyFormID(int meetingApplyFormID)
        {
            List<Model.ArrMeetingEquipmentInfo> listResult = new List<Model.ArrMeetingEquipmentInfo>();

            var q = (from m in dc.MeetingEquipment
                     join e in dc.MeetingAndEquipment on m.MeetingEquipmentID equals e.MeetingEquipmentID
                     where e.MeetingApplyFormID == meetingApplyFormID
                     select new
                     {
                         m.MeetingEquipmentID,
                         m.EquipmentName,
                         e.MeetingEquipmentCount
                     }).ToList();


            listResult = (List<Model.ArrMeetingEquipmentInfo>)q.Select(
                 t => new Model.ArrMeetingEquipmentInfo()
                 {
                     MeetingEquipmentID = t.MeetingEquipmentID,
                     EquipmentCount = t.MeetingEquipmentCount,
                     EquipmentName = t.EquipmentName
                 }).ToList();
            return listResult;
        }

        public List<Model.ArrMeetingEquipmentInfo> GetEquipmentDetailListByMeetingApplyFormID()
        {
            List<Model.ArrMeetingEquipmentInfo> listResult = new List<Model.ArrMeetingEquipmentInfo>();

            var q = (from m in dc.MeetingApplyForm
                     join e in dc.MeetingAndEquipment on m.MeetingApplyFormID equals e.MeetingApplyFormID
                     join equipment in dc.MeetingEquipment on e.MeetingAndEquipmentID equals equipment.MeetingEquipmentID
                     join meetinandroom in dc.MeetingAndRoom on m.MeetingApplyFormID equals meetinandroom.MeetingApplyFormID
                     join meetingroom in dc.MeetingRoom on meetinandroom.MeetingRoomID equals meetingroom.MeetingRoomID
                     select new
                     {
                         m.MeetingApplyFormID,
                         m.BeginTime,
                         m.EndTime,
                         meetingroom.MeetingRoomName,
                         equipment.EquipmentName,
                         e.MeetingEquipmentCount
                     }).ToList();


            listResult = (List<Model.ArrMeetingEquipmentInfo>)q.Select(
                 t => new Model.ArrMeetingEquipmentInfo()
                 {
                     MeetingApplyFormID = t.MeetingApplyFormID,
                     BeginTime = t.BeginTime,
                     EndTime = t.EndTime,
                     EquipmentCount = t.MeetingEquipmentCount,
                     EquipmentName = t.EquipmentName,
                     MeetingRoomName = t.MeetingRoomName
                 }).ToList();
            return listResult;
        }

        #endregion



        #region IMeetingEquipment 成员


        public void UpdateFreeCount(int useed, int meetingEquipmentID)
        {
            var query = dc.MeetingEquipment.Single(p => p.MeetingEquipmentID == meetingEquipmentID);
            query.MeetingEquipmentFreeCount = query.MeetingEquipmentFreeCount - useed;
            dc.SubmitChanges();
        }

        #endregion

        #region IMeetingEquipment 成员


        public Dictionary<int, int> GetEquipmentIDAndUsedCount(int meetingApplyFormID)
        {
            Dictionary<int, int> result = new Dictionary<int, int>();
            var query = from equipment in dc.MeetingAndEquipment
                        where equipment.MeetingApplyFormID == meetingApplyFormID
                        select equipment;
            foreach (var q in query)
            {
                int equipmentID = q.MeetingEquipmentID;
                int used = q.MeetingEquipmentCount;
                result.Add(equipmentID, used);
            }
            return result;
        }

        #endregion

        #region IMeetingEquipment 成员


        public void ReturnEquipmentCount(int meetingEquipmengID, int used)
        {
            var query = dc.MeetingEquipment.Single(p => p.MeetingEquipmentID == meetingEquipmengID);
            query.MeetingEquipmentFreeCount = query.MeetingEquipmentFreeCount + used;
            dc.SubmitChanges();
        }

        #endregion
    }
}
