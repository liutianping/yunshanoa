using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YunShanOA.TableCacheDependency
{
    public class Car : TableDependency
    {
        /// <summary>
        /// 传入从配置文件里面缓存设置机制
        /// </summary>
        public Car() : base("CarTableDependency") { }
    }
}
