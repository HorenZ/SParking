using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    public class PartInfoBLL
    {
        public static List<PartInfo> GetAllPartAddress()
        {
            return new PartInfoDAL().GetAllPartAddress();
        }
    }
}
