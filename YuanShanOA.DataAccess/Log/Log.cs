using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YunShanOA.IDataAccess;

namespace YunShanOA.DataAccess.Log
{
    public class Log:ILog
    {

        #region ILog 成员
        YunShanOA.DataAccess.Mapping.YunShanOADataContext dc = new Mapping.YunShanOADataContext();
        public void InsertLog(YunShanOA.Model.Log logModel)
        {
            if (logModel != null)
            {


                YunShanOA.DataAccess.Mapping.Log log = new Mapping.Log();
                log.LogType = logModel.LogTypeID;
                log.LogContent = logModel.LogContext;
                log.UserName = logModel.userName;
                dc.Log.InsertOnSubmit(log);
                dc.SubmitChanges();
            }
        }

        public List<Model.Log> GetLog()
        {
            List<Model.Log> result = new List<Model.Log>();
            var query = (from l in dc.Log select new { l.UserName,l.LogTime,l.LogContent }).ToList();
            return query.Select(p => new Model.Log() { 
              userName=p.UserName,LogContext=p.LogContent, LogTime=p.LogTime
            }).ToList();
        }

        public List<Model.Log> GetLogByUserName(string userName)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
