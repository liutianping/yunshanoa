using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YunShanOA.IDAL.MeetingInterface;
using YunShanOA.Model;
using System.Data.Linq;

namespace YunShanOA.DataAccess.Meeting
{
    public class MeetingTypeHelp : IMeetingType
    {
        #region IMeetingType 成员
        YunShanOA.DataAccess.Mapping.YunShanOADataContext dc = null;

        /// <summary>
        /// 删除会议类型
        /// </summary>
        /// <param name="mt">要删除的会议业务对象</param>
        /// <returns>返回成功与否</returns>
        public bool DeleteMeetingType(Model.MeetingType mt)
        {
            
            YunShanOA.DataAccess.Mapping.MeetingType meetingType = null;
            dc = new Mapping.YunShanOADataContext();
            meetingType = (from meeting in dc.MeetingType
                           where meeting.MeetingTypeID == mt.MeetingTypeID
                           select meeting).FirstOrDefault();
            if (meetingType != null)
            {
                try
                {
                    dc.MeetingType.DeleteOnSubmit(meetingType);
                    dc.SubmitChanges();
                }
                catch (ChangeConflictException)
                {
                    dc.ChangeConflicts.ResolveAll(RefreshMode.OverwriteCurrentValues);
                    dc.SubmitChanges();
                }
            }
            
            return (meetingType!=null);
        }

        /// <summary>
        /// 获取所有的会议类型
        /// </summary>
        /// <returns>返回所有会议类型的集合</returns>
        public List<Model.MeetingType> GetMeetingType()
        {
            List<MeetingType> result = new List<MeetingType>();
            dc = new Mapping.YunShanOADataContext();
            var Query = from meeting in dc.MeetingType select meeting;
            foreach (var m in Query)
            {
                result.Add(FillRecord(m));
            }
            return result;
        }

        /// <summary>
        /// 根据MeetingTypeID查询业务实体
        /// </summary>
        /// <param name="mtID">会议ID</param>
        /// <returns>业务实体对象</returns>
        public Model.MeetingType GetMeetingTypeByMtID(int mtID)
        {
            dc = new Mapping.YunShanOADataContext();
            var query = (from meeting in dc.MeetingType 
                        where meeting.MeetingTypeID == mtID 
                        select meeting).FirstOrDefault();
            return FillRecord(query);
        }

        /// <summary>
        /// 会议类型的保存和更新
        /// </summary>
        /// <param name="mt">要保存或更新的MeetingType对象</param>
        /// <returns>返回MeetingTypeID</returns>
        public int SaveMeetingType(MeetingType mt)
        {
            
            YunShanOA.DataAccess.Mapping.MeetingType meetingType = null;
            dc = new Mapping.YunShanOADataContext();
            bool find = false;

            if (mt.MeetingTypeID == -1)
            {
                meetingType = new Mapping.MeetingType();
                dc.MeetingType.InsertOnSubmit(meetingType);
                find = true;
            }
            else
            {
                meetingType = (from meeting in dc.MeetingType
                               where meeting.MeetingTypeID == mt.MeetingTypeID
                               select meeting).FirstOrDefault();
                if (meetingType != null)
                {
                    find = true;
                    meetingType.MeetingTypeID = mt.MeetingTypeID;
                }
            }

            if (find)
            {
                meetingType.MeetingTypeName = mt.MeetingTypeName;
                meetingType.MeetingTypeDescription = mt.MeetingTypeDescription;

                try
                {
                    dc.SubmitChanges();
                }
                catch (ChangeConflictException)
                {
                    dc.ChangeConflicts.ResolveAll(RefreshMode.OverwriteCurrentValues);
                    dc.SubmitChanges();
                }
                return meetingType.MeetingTypeID;
            }
            else
            {
                return -1;
            }


           

        }

        /// <summary>
        /// 将数据表的数据封装为业务对象
        /// </summary>
        /// <param name="mt">数据表的单行记录</param>
        /// <returns>一个业务对象</returns>
        private YunShanOA.Model.MeetingType FillRecord(YunShanOA.DataAccess.Mapping.MeetingType mt)
        {
            YunShanOA.Model.MeetingType meetingType = null;
            if (mt != null)
            {
                meetingType = new MeetingType();
                meetingType.MeetingTypeID = mt.MeetingTypeID;
                meetingType.MeetingTypeName = mt.MeetingTypeName;
                meetingType.MeetingTypeDescription = mt.MeetingTypeDescription;
            }

            return meetingType;
        }
        #endregion
    }
}
