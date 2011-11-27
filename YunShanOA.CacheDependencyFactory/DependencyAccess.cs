using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using YunShanOA.ICacheDependency;
using System.Configuration;

namespace YunShanOA.CacheDependencyFactory
{
   public static  class DependencyAccess
    {
       public static ICacheDependency.IYunShanOACacheDependency CreateCarDependency()
       {
           return LoadInstance("Car");
       }

       public static ICacheDependency.IYunShanOACacheDependency CreateMeetingApplyFormdency()
       {
           return LoadInstance("MeetingApplyForm");
       }
       private static IYunShanOACacheDependency LoadInstance(string className)
       {
           string path = ConfigurationManager.AppSettings["CacheDependencyAssembly"];
           string fullyQualifiedClass = path + "." + className;
           return (IYunShanOACacheDependency)Assembly.Load(path).CreateInstance(fullyQualifiedClass);
       }
    }

}
