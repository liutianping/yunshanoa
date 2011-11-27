using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YunShanOA.BusinessLogic
{
    public class MeetingRoom
    {
        public static List<Model.MeetingRoom> GetListMeetingRoom()
        {
            return DALFactory.MeetingInstanceFactory.GetMeetingRoomInstance().GetListMeetingRoom();
        }

        public static List<Model.MeetingRoom> GetListMeetingRoomNotIn(DateTime beginTime, DateTime endTime)
        {
            return DALFactory.MeetingInstanceFactory.GetMeetingRoomInstance().GetListMeetingRoomNotIn(beginTime, endTime);
        }

        public static List<Model.ArrMeetingEquipmentInfo> GetWillArrMeetingRoomList()
        {
            return DALFactory.MeetingInstanceFactory.GetMeetingRoomInstance().GetWillArrMeetingRoomList();
        }

        public static int GetMeetingApplyFormIDByMeetingMeetingAndRoomID(int meetingandroomid)
        {
            return DALFactory.MeetingInstanceFactory.GetMeetingRoomInstance().GetMeetingApplyFormIDByMeetingMeetingAndRoomID(meetingandroomid);
        }

        public static string GetMeetingRoomNameByMeetingApplyFormID(int meetingApplyFormID)
        {
            return DALFactory.MeetingInstanceFactory.GetMeetingRoomInstance().GetMeetingRoomNameByMeetingApplyFormID(meetingApplyFormID);
        }

        public static void UpdateMeetingAndRoomStatus(int marID, int newStatus)
        {
            DALFactory.MeetingInstanceFactory.GetMeetingRoomInstance().UpdateMeetingAndRoomStatus(marID, newStatus);
        }

        public static void SaveMeetingRoom(Model.MeetingRoom mr)
        {
            DALFactory.MeetingInstanceFactory.GetMeetingRoomInstance().SaveMeetingRoom(mr);
        }
    }
}
