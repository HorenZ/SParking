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
        /// <summary>
        /// 保存订单  返回true为失败
        /// </summary>
        /// <param name="his"></param>
        /// <returns></returns>
        public bool SaveHistory(History his)
        {
            int e = new HistoryDAL().SaveHistory(his);
            if (e!=1)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// 获取最新HID
        /// </summary>
        /// <returns></returns>
        public int GetNewHID()
        {
            return new HistoryDAL().GetNewHID();
        }

        /// <summary>
        /// 更新position
        /// </summary>
        /// <param name="Posintion"></param>
        /// <param name="hid"></param>
        /// <returns></returns>
        public bool UpdateParkPosition(string Posintion, int hid)
        {
            int i = new HistoryDAL().UpdateParkPosition(Posintion, hid.ToString());
            if (i!=1)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// 判断用户存在未完成的订单
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public bool IsNoPayOrder(string username)
        {
            int i = new HistoryDAL().IsNoPayOrder(username);
            if (i!=0)
            {
                return true;
            }

            return false;
        }
    }
}
