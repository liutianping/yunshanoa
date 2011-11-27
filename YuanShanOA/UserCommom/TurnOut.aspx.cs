using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YunShanOA.UserCommom
{
    public partial class TurnOut : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Master.Holdermenu7 = "用车管理&nbsp;»&nbsp;待出车信息";
                BusinessLogic.UseCar.UsecarApplyformManager uafm = new BusinessLogic.UseCar.UsecarApplyformManager();
               
                
                //string userName = Page.User.Identity.Name;
                string userName = "admin11111";
                List<Model.UseCarModel.NeedRide> result= uafm.GetNeedRide(userName);
                if (0 != result.Count)
                {
                    GridView1.DataSource = result;
                    GridView1.DataBind();
                }
                else
                {
                    lblMessage.Visible = true;
                    lblMessage.Text = "您暂无出车信息";
                }
            }
        }
    }
}