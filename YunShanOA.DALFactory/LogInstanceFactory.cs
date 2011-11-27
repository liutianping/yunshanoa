using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using YunShanOA.IDAL.IUseCar;
using System.Reflection;
using YunShanOA.IDataAccess;


namespace YunShanOA.DALFactory
{
    public class LogInstanceFactory
    {
        private static readonly string PATH = ConfigurationManager.AppSettings["SqlServerDataAccess"];
        /// <summary>
        /// 动态创建ILog对象
        /// </summary>
        /// <returns></returns>
        public static ILog GetLogInstance()
        {
            string className = PATH + ".Log.Log";

            return (ILog)Assembly.Load(PATH).CreateInstance(className);
        }

    }
}
