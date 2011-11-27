using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YunShanOA.Workflow.UseCar
{
    public class ArrangeDrawOutFrom
    {
        public string UseCarInfromID { get; set; }
        private List<string> _carListID;
        public Guid WFID { get; set; }
        public List<string> CarIDList
        {
            get { return _carListID; }
            set { _carListID = value; }
        }
        public string Msg { get; set; }
    }
}
