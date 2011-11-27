using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YunShanOA.BusinessLogic
{
    public class Log
    {
        public static void SaveLog(YunShanOA.Model.Log log)
        {
            DALFactory.LogInstanceFactory.GetLogInstance().InsertLog(log);
        }

        public static List<Model.Log> GetListLog()
        {
            return DALFactory.LogInstanceFactory.GetLogInstance().GetLog();
        }

        public static List<Model.Log> GetListLogByUserName(string userName)
        {
            return DALFactory.LogInstanceFactory.GetLogInstance().GetLogByUserName(userName);
        }
    }
}
