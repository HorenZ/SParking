using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Model;

namespace DAL
{
    public class CarInfoDAL
    {
        /// <summary>
        /// 获取用户的车辆信息，以集合形式返回
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public List<string> GetUserCarInfo(UserInfo user)
        {
            //准备参数
            List<string> list = new List<string>();
            SqlParameter para=new SqlParameter("@UserName",user.UserName);
            string sqlcmd = "Select CarNum From CarInfo Where UserName=@UserName";
            //调用底层方法进行查询
            SqlDataReader reader = SqlHelper.ExecuteReader(
                SqlHelper.ConnectionString,
                CommandType.Text,
                sqlcmd,
                para
            );
            while (reader.Read())
            {
                list.Add(reader[0].ToString());
            }

            return list;
        }
        /// <summary>
        /// 删除车辆
        /// </summary>
        /// <param name="username"></param>
        /// <param name="carNum"></param>
        /// <returns></returns>
        public bool DeleteCar(string username,string carNum)
        {
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@UserName", username);
            para[1] = new SqlParameter("@CarNum", carNum);
            string sqlcmd = "Delete From CarInfo Where UserName=@UserName and CarNum=@CarNum";
            int e = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString,
                CommandType.Text,
                sqlcmd,
                para
            );
            if (e == 0)
            {
                return false;
            }

            return true;
        }
    }
}
