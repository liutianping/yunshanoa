using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YunShanOA.Model;

namespace YunShanOA.IDAL.MeetingInterface
{
    public interface IMeetingRoom
    {
        
        int SaveMeetingRoom(MeetingRoom meetingAndRoom);

        bool DeleteMeetingRoom(MeetingRoom meetingAndRoom);

        List<Model.ArrMeetingEquipmentInfo> GetWillArrMeetingRoomList();

        List<MeetingRoom> GetListMeetingRoom();

        MeetingRoom QueryMeetingRoomByName(string roomName); 

        List<MeetingRoom> GetListMeetingRoomByStatus(int status);

        List<MeetingRoom> GetListMeetingRoomNotIn(DateTime beginTime, DateTime endTime);

        int GetMeetingApplyFormIDByMeetingMeetingAndRoomID(int meetingAndRoomID);

        string GetMeetingRoomNameByMeetingApplyFormID(int meetingApplyFormID);

        void UpdateMeetingAndRoomStatus(int applyFormID,int newStatus);

    }
}
