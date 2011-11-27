using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YunShanOA.Model.UseCarModel
{
    public class car
    {
        private int _CarId = -1;

        public int CarId
        {
            get { return _CarId; }
            set { _CarId = value; }
        }
        private usecartype _usecartype = new usecartype();

        public usecartype Usecartype
        {
            get { return _usecartype; }
            set { _usecartype = value; }
        }
        /// <summary>
        /// 牌照
        /// </summary>
        public string LicenseNumber { get; set; }
        /// <summary>
        /// 型号
        /// </summary>
        public string ModelNumber { get; set; }
        public int seatingNumber { get; set; }
        public string LoadCapacity { get; set; }
        public string Comment { get; set; }
        public int Status { get; set; }
        public string Driver { get; set; }
        public string DriverEmail { get; set; }
    }
}
