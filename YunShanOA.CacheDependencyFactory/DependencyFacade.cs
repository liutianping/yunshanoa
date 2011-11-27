using System.Configuration;
using System.Web.Caching;
using System.Collections.Generic;

namespace YunShanOA.CacheDependencyFactory
{
    public static class DependencyFacade
    {
        private static readonly string path = ConfigurationManager.AppSettings["CacheDependencyAssembly"];

        /// <summary>
        /// 获取缓存依赖集合
        /// </summary>
        /// <returns></returns>
        public static AggregateCacheDependency GetCarDependency()
        {
            if (!string.IsNullOrEmpty(path))
                return DependencyAccess.CreateCarDependency().GetDependency();
            else
                return null;
        }

        public static AggregateCacheDependency GetMeetingApplyFormDependency()
        {
            if (!string.IsNullOrEmpty(path))
                return DependencyAccess.CreateMeetingApplyFormdency().GetDependency();
            else
                return null;
        }
    }
}
