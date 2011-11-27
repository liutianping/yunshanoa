using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YunShanOA.Model.UseCarModel;

namespace YunShanOA.Workflow.UseCar
{
    public class RequestForm
    {
        public string ApplyUserName { get; set; }
        public int usecartypeID { get; set; }
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
        public string ApplyReason { get; set; }
        public string Comment { get; set; }
    }
}
