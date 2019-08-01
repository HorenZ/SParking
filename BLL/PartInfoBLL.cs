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

        /// <summary>
        /// 通过停车场名字查询ID
        /// </summary>
        /// <param name="name">ParkName</param>
        /// <returns>ID</returns>
        public int GetIdByName(string name)
        {
            return new PartInfoDAL().GetIdByName(name);
        }
        /// <summary>
        /// 通过停车场ID查询名字
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetNameById(int id)
        {
            return new PartInfoDAL().GetNameById(id);
        }
    }
}
