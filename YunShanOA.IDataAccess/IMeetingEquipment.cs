using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YunShanOA.Model;

namespace YunShanOA.IDAL.MeetingInterface
{
    public interface IMeetingEquipment
    {
        int SaveMeetingEquipment(MeetingEquipment meetingAndEquipment);

        bool DeleteMeetingEquipment(MeetingEquipment meetingAndEquipment);

        List<MeetingEquipment> GetListMeetingEquipment();

        MeetingEquipment QueryMeetingEquipmentByName(string EquipmentName);

        List<MeetingEquipment> GetListMeetingEquipmentByStatus(int status);

        List<Model.ArrMeetingEquipmentInfo> GetEquipmentDetailListByMeetingApplyFormID(int meetingApplyFormID);

        List<Model.ArrMeetingEquipmentInfo> GetEquipmentDetailListByMeetingApplyFormID();

        void UpdateFreeCount(int useed,int meetingEquipmentID);

        Dictionary<int, int> GetEquipmentIDAndUsedCount(int meetingApplyFormID);

        void ReturnEquipmentCount(int meetingEquipmengID,int used);
    }
}
