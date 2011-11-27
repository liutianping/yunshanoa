using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YunShanOA.WebAdmin
{
    public partial class MeetingRoomManager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Master.Holdermenu8 = "后台管理&nbsp;»&nbsp;会议室管理";
        }

        protected void btnTrue_Click(object sender, EventArgs e)
        {
            Model.MeetingRoom mr = new Model.MeetingRoom();
            mr.MeetingRoomName = txtMeetingRoomName.Text.Trim();
            mr.MeetingRoomCapacity = int.Parse(txtCap.Text);
            mr.MeetingRoomStatus = 3;
            mr.MeetingTypeID = int.Parse(this.ddlType.SelectedValue);
            BusinessLogic.MeetingRoom.SaveMeetingRoom(mr);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

        }
        protected void GridView1_RowDataBound1(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ((LinkButton)e.Row.Cells[0].Controls[0]).OnClientClick = "if(!confirm('確定要刪除嗎'))return false;";
            }
        }
    }
}