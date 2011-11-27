using System.Web.Caching;


namespace YunShanOA.ICacheDependency
{
    /// <summary>
    /// 缓存缓存依赖的集合
    /// </summary>
    public interface IYunShanOACacheDependency
    {
        AggregateCacheDependency GetDependency();
        
    }
}
