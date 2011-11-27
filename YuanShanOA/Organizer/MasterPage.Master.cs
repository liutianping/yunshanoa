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
        public string Holdermenu3
        {
            get { return this.holdermenu3.Text; }
            set { this.holdermenu3.Text = value; }

        }
    }

   
}