using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YunShanOA.Model.UseCarModel
{
    public class usecaranduser
    {
        private int _UseCarUserId = -1;

        public int UseCarUserId
        {
            get { return _UseCarUserId; }
            set { _UseCarUserId = value; }
        }
        public int UseCarApplyFormID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
