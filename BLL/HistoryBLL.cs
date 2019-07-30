using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Model;

namespace BLL
{
    public class HistoryBLL
    {
        public bool SaveHistory(History his)
        {
            return new HistoryDAL().SaveHistory(his);
        }
    }
}
