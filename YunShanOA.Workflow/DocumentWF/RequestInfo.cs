using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YunShanOA.Workflow.DocumentWF
{
   public  class requestinfo
    {
       public string DocumentName { get;set;}
       public string DocumentPath { get; set; }
       public string Author { get; set; }
       public string Email { get;set;}
       public bool IsNeed { get; set; }
    }
}
