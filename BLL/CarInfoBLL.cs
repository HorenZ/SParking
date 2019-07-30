using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Model;

namespace BLL
{
    public class CarInfoBLL
    {
        /// <summary>
        /// 获取用户汽车信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public List<string> GetUserCarInfo(UserInfo user)
        {
            return new CarInfoDAL().GetUserCarInfo(user);
        }
        /// <summary>
        /// 添加汽车
        /// </summary>
        /// <param name="name"></param>
        /// <param name="carnum"></param>
        /// <returns></returns>
        public bool AddCar(string name, string carnum)
        {
            return new UserInfoDAL().AddCar(name, carnum);
        }

        /// <summary>
        /// 删除车辆
        /// </summary>
        /// <param name="username"></param>
        /// <param name="carNum"></param>
        /// <returns></returns>
        public bool DeleteCar(string username, string carNum)
        {
            return new CarInfoDAL().DeleteCar(username, carNum);
        }
    }
}
