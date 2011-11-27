using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YunShanOA.Model.DocumentModel
{
    public class documentTemplate
    {
        private int _ID = -1;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public string DocumentTemplateName { get; set; }
        public string DocumentTemplateDescription { get; set; }
        public string DocumentTemplatePath { get; set; }
    }
}
