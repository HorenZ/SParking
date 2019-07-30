using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class PartInfo
    {
        public int ParkID { get; set; }
        public string Name { get; set; }
        public int ProvinceID { get; set; }
        public string Address { get; set; }
        public decimal Price { get; set; }
        public bool State { get; set; }
        public float Grade { get; set; }
        public bool Choose { get; set; }

    }
}
