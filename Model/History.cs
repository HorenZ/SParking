﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class History
    {
        public string PortName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime AllTime { get; set; }
        public decimal Cost { get; set; }
        public decimal PortPrice { get; set; }
        public string UserName { get; set; }
        public bool State { get; set; }
        public string CarNum { get; set; }
    }
}