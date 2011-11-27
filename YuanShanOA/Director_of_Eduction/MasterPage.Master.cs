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
        public string Holdermenu1
        {
            get { return this.holdermenu1.Text; }
            set { this.holdermenu1.Text = value; }

        }
    }

   
}