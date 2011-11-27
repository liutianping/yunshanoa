using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YunShanOA.Model.UseCarModel
{
    public class archivusercarapply
    {
        private int _ArchiveUserCarID = -1;

        public int ArchiveUserCarID
        {
            get { return _ArchiveUserCarID; }
            set { _ArchiveUserCarID = value; }
        }
        private usecarapplyform usecarapplyform = new usecarapplyform();

        public usecarapplyform Usecarapplyform
        {
            get { return usecarapplyform; }
            set { usecarapplyform = value; }
        }
        public string FileName { get; set; }
        public string FilePath { get; set; }
    }
}
