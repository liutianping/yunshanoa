using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YunShanOA.Model.UseCarModel
{
    public class usecartype
    {
        private int _UseCarTypeID = -1;

        public int UseCarTypeID
        {
            get { return _UseCarTypeID; }
            set { _UseCarTypeID = value; }
        }
  
        public string UseCarTypeName { get; set; }
    }
}

