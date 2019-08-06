using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Model;

namespace BLL
{
    public class ApplyInfoBLL
    {
        /// <summary>
        /// 返回true
        /// </summary>
        /// <param name="apply"></param>
        /// <returns></returns>
        public bool CreateOrder(ApplyInfo apply)
        {
            int e = new ApplyInfoDAL().CreateOrder(apply);
            //e!=1  保存失败
            if (e != 1)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// 查询订车库的结果是否成功
        /// </summary>
        /// <param name="hid"></param>
        /// <returns></returns>
        public ApplyInfo QueryOrderResult(string hid)
        {
            return new ApplyInfoDAL().QueryOrderResult(hid);
        }
    }
}
