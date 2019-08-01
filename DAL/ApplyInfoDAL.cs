using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web.Configuration;
using Model;

namespace DAL
{
    public class ApplyInfoDAL
    {
        /// <summary>
        /// 生成活跃订单
        /// </summary>
        /// <param name="apply"></param>
        /// <returns></returns>
        public int CreateOrder(ApplyInfo apply)
        {
            SqlParameter[] paras=new SqlParameter[5];
            paras[0]=new SqlParameter("HID",apply.HID);
            paras[1] = new SqlParameter("CarNum", apply.CarNum);
            paras[2] = new SqlParameter("ParkID", apply.ParkID);
            paras[3] = new SqlParameter("ParkPosintion", apply.ParkPosintion);
            paras[4] = new SqlParameter("State", apply.State);
            string sqltxt = "Insert into ApplyInfo Values(@HID,@CarNum,@ParkID,@ParkPosintion,@State)";
            int e = SqlHelper.ExecuteNonQuery(
                WebConfigurationManager.ConnectionStrings["SqlConnectionString1"].ToString(),
                CommandType.Text,
                sqltxt,
                paras);
            return e;
        }
    }
}
