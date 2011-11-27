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
        public string Holdermenu4
        {
            get { return this.holdermenu4.Text; }
            set { this.holdermenu4.Text = value; }

        }
    }

   
}