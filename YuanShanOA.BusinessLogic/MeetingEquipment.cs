using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YunShanOA.IDAL.MeetingInterface;


namespace YunShanOA.BusinessLogic
{
    public class MeetingEquipment
    {
        private static readonly IMeetingEquipment meetingEquipment = YunShanOA.DALFactory.MeetingInstanceFactory.GetMeetingEquipmentInstance();

        public static List<YunShanOA.Model.MeetingEquipment> GetAllMeetingequipment()
        {
            return meetingEquipment.GetListMeetingEquipment();
        }

        public static List<Model.ArrMeetingEquipmentInfo> GetListMeetingEquipmentByMeetingApplyFormID(int meetingApplyFormID)
        {
            return meetingEquipment.GetEquipmentDetailListByMeetingApplyFormID(meetingApplyFormID);
        }

        public static List<Model.ArrMeetingEquipmentInfo> GetAllListMeetingEquipmentDetails()
        {
            return meetingEquipment.GetEquipmentDetailListByMeetingApplyFormID();
        }

        public static void UpdateFreeCount(int usrd, int meetingEquipmentID)
        {
            meetingEquipment.UpdateFreeCount(meetingEquipmentID, usrd);
        }

        public static Dictionary<int, int> GetMeetingEquipmentIDAndCount(int meetingApplyFormID)
        {
            return meetingEquipment.GetEquipmentIDAndUsedCount(meetingApplyFormID);
        }

        public static void ReturnEquipmentCount(int meetingEquipmentID, int used)
        {
            meetingEquipment.ReturnEquipmentCount(meetingEquipmentID, used);
        }
    }
}
