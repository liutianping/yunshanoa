using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YunShanOA.Model
{
    public class Log
    {
        public int LogID { get; set; }
        public string userName { get; set; }
        public string LogContext { get; set; }
        public string LogTypeID { get; set; }
        public DateTime? LogTime { get; set; }
    }
}
