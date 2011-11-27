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
    }
}
