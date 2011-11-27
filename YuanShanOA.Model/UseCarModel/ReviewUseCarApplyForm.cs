using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YunShanOA.Model.UseCarModel
{
    public class ReviewUseCarApplyForm
    {
        private int _ReviewUseCarApplyID = -1;

        public int ReviewUseCarApplyID
        {
            get { return _ReviewUseCarApplyID; }
            set { _ReviewUseCarApplyID = value; }
        }
        public int UseCarApplyFormID { get; set; }
        public string ReviewUserName { get; set; }
        public int Agree { get; set; }
    }
}
