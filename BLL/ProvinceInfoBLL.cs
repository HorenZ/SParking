using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Model;

namespace BLL
{
    public class ProvinceInfoBLL
    {
        public List<ProvinceInfo> GetAllProvinceInfo()
        {
            return new ProvinceInfoDAL().GetAllProvinceInfo();
        }
    }
}
