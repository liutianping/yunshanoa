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
        public string Holdermenu8
        {
            get { return this.holdermenu8.Text; }
            set { this.holdermenu8.Text = value; }

        }
    }

   
}