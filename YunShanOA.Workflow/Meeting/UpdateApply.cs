using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using YunShanOA.DataAccess.Mapping;

namespace YunShanOA.Workflow.Meeting
{

    public sealed class UpdateApply : CodeActivity
    {

        public InArgument<YunShanOA.DataAccess.Mapping.MeetingApplyForm> UpdateApplyInfo { get; set; }
        public InArgument<Dictionary<int, int>> MeetingEquipmentNameAndCount { get; set; }
        public InArgument<Dictionary<string, string>> MeetingUserNameAndEmail { get; set; }
        public InArgument<YunShanOA.Model.MeetingRoom> MeetingRoomIDAndName { get; set; }

        public InArgument<int> State { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            int resultState = State.Get(context);
            YunShanOA.DataAccess.Mapping.YunShanOADataContext dc = new DataAccess.Mapping.YunShanOADataContext();
            MeetingApplyForm query = (from p in dc.MeetingApplyForm where p.WFID == UpdateApplyInfo.Get(context).WFID select p).FirstOrDefault();
            MeetingApplyForm info = query;
            info.MeetingStatus = resultState;
            dc.SubmitChanges();
            int meetingApplyFormID = ((from p in dc.MeetingApplyForm where p.WFID == UpdateApplyInfo.Get(context).WFID select p).FirstOrDefault()).MeetingApplyFormID;
            //如果审核通过，将会议申请所选的设备持久化到数据库
            if (resultState == 1)
            {
                YunShanOA.DataAccess.Mapping.MeetingAndEquipment mae = null;
                //提交会议申请中的所填写的会议设备申请
                if (null != MeetingEquipmentNameAndCount.Get(context))
                {
                    foreach (var item in MeetingEquipmentNameAndCount.Get(context))
                    {
                        mae = new MeetingAndEquipment();
                        mae.MeetingApplyFormID = meetingApplyFormID;
                        mae.MeetingEquipmentID = item.Key;
                        mae.MeetingEquipmentCount = item.Value;
                        dc.MeetingAndEquipment.InsertOnSubmit(mae);
                        dc.SubmitChanges();
                    }
                }

                ////提交会议申请中所选择的会议室
                //if (null != MeetingRoomIDAndName.Get(context))
                //{
                //    YunShanOA.DataAccess.Mapping.MeetingAndRoom mr = new MeetingAndRoom();
                //    mr.MeetingApplyFormID = meetingApplyFormID;
                //    mr.MeetingRoomID = MeetingRoomIDAndName.Get(context).MeetingRoomID;
                //    mr.Status = 2;
                //    dc.MeetingAndRoom.InsertOnSubmit(mr);
                //    dc.SubmitChanges();

                //}
                //提交会议申请中选择的用户名
                if (null != MeetingUserNameAndEmail.Get(context))
                {
                    YunShanOA.DataAccess.Mapping.MeetingAndUser mau = null;
                    foreach (var item in MeetingUserNameAndEmail.Get(context))
                    {
                        mau = new MeetingAndUser();
                        mau.MeetingApplyFormID = meetingApplyFormID;
                        mau.UserName = item.Value;
                        dc.MeetingAndUser.InsertOnSubmit(mau);
                        dc.SubmitChanges();
                    }
                }

            }
        }
    }
}
