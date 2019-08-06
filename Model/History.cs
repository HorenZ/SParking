using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class History
    {
        public int HID { get; set; }
        public string PortName { get; set; }
        public DateTime BookTime { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime AllTime { get; set; }
        public decimal Cost { get; set; }
        public decimal PortPrice { get; set; }
        public string UserName { get; set; }
        
        /// <summary>
        /// 订单是否结束 -1:未订车库 0:已订车库 但还未入库  1:已入库 未出库  2:完成停车 但未支付  3:订单完成
        /// </summary>
        public int State { get; set; }
        public string CarNum { get; set; }
        public string ParkPosintion { get; set; }
    }
}
