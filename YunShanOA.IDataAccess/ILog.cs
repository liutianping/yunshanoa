using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YunShanOA.Model;

namespace YunShanOA.IDataAccess
{
    public interface ILog
    {
        void InsertLog(YunShanOA.Model.Log log);
        List<YunShanOA.Model.Log> GetLog();
        List<Log> GetLogByUserName(string userName);
    }
}
