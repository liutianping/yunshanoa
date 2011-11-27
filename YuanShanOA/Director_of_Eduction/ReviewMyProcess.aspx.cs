using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Caching;
using System.Configuration;

namespace YunShanOA.Director_of_Eduction
{
    public partial class ReviewMyProcess : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //todo 这里要取消注释
                string userName = "张三";
                //string key = "reviewMeeting_by_"+Page.User.Identity.Name;
                string key = "reviewMeeting_by_" +userName;
                IList<Model.Meeting> result=(IList<Model.Meeting>)HttpRuntime.Cache[key];
                if (null == result)
                {
                    int cacheTime=Int32.Parse(ConfigurationManager.AppSettings["MeetingApplyFormCacheDuration"]);
                    result = BusinessLogic.ReviewMeeting.GetReviewMeetingList(userName);
                    AggregateCacheDependency cd=YunShanOA.CacheDependencyFactory.DependencyFacade.GetMeetingApplyFormDependency();
                    HttpRuntime.Cache.Add(key, result, cd, DateTime.Now.AddHours(cacheTime), System.Web.Caching.Cache.NoSlidingExpiration, CacheItemPriority.High, null);
                }
                GridView1.DataSource = result;
                GridView1.DataBind();
            }
        }
    }
}