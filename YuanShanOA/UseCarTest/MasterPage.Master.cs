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
        public string Holdermenu6
        {
            get { return this.holdermenu6.Text; }
            set { this.holdermenu6.Text = value; }

        }
    }

   
}