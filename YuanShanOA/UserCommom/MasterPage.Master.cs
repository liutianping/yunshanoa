using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YuanShanOA
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        public string Holdermenu7
        {
            get { return this.holdermenu7.Text; }
            set { this.holdermenu7.Text = value; }

        }
    }

   
}