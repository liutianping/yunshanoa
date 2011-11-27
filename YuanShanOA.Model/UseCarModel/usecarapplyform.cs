using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YunShanOA.Model.UseCarModel
{
    public class usecarapplyform
    {
        private int _UseCarApplyFormID = -1;

        public int UseCarApplyFormID
        {
            get { return _UseCarApplyFormID; }
            set { _UseCarApplyFormID = value; }
        }
        public string ApplyUserName { get; set; }
        public usecartype usecartype{ get; set; }
        private List<usecaranduser> _usecaranduser = new List<usecaranduser>();
       
        public List<usecaranduser> Usecaranduser
        {
            get { return _usecaranduser; }
            set { _usecaranduser = value; }
        }
        public DateTime BeginTime { get; set; }
        public DateTime EndTime { get; set; }
        public string StartDestination { get; set; }
        public string EndDestination { get; set; }
        public int ApplyStatus { get; set; }
        public string ApplyReason { get; set; }
        public Guid WFID { get; set; }
        public string Comment { get; set; }
        
    }
}
