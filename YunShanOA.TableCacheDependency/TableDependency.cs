using System.Web.Caching;
using System.Configuration;

namespace YunShanOA.TableCacheDependency
{
    public abstract class TableDependency : YunShanOA.ICacheDependency.IYunShanOACacheDependency
    {
        protected char[] configurationSeparator = new char[] { ',' };

        protected AggregateCacheDependency dependency = new AggregateCacheDependency();

        
        protected TableDependency(string configKey)
        {
            string dbName = ConfigurationManager.AppSettings["CacheDatabaseName"];
            string tableConfig = ConfigurationManager.AppSettings[configKey];
            string[] tables = tableConfig.Split(configurationSeparator);

            foreach (string tableName in tables)
                dependency.Add(new SqlCacheDependency(dbName, tableName));
        }
        
        /// <summary>
        /// 返回多个依赖项的集合
        /// </summary>
        /// <returns></returns>
        public AggregateCacheDependency GetDependency()
        {
            return dependency;
        }
    }
}
