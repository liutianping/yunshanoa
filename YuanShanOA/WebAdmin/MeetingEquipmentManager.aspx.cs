using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YunShanOA.WebAdmin
{
    public partial class MeetingEquipmentManager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Master.Holdermenu8 = "后台管理&nbsp;»&nbsp;会议设备管理";
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ((LinkButton)e.Row.Cells[0].Controls[0]).OnClientClick = "if(!confirm('確定要刪除嗎'))return false;";
            }
        }
    }
}