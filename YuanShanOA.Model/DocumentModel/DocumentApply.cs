using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YunShanOA.Model.DocumentModel
{
    public class DocumentApply
    {
        private int _DocumentID = -1;

        public int DocumentID
        {
            get { return _DocumentID; }
            set { _DocumentID = value; }
        }
        public Guid WFID { get; set; }
        public int Status { get;set;}
        public string DocumentName { get; set; }
        public string DocumentPath { get; set; }
        public string Author { get; set; }
        public bool IsNeed { get; set; }
    }
}
