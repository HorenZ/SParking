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
        /// 添加车辆信息
        /// </summary>
        /// <param name="para1"></param>
        /// <param name="para2"></param>
        /// <returns>
        /// true:成功
        /// false:失败
        /// </returns>
        public bool AddCar(SqlParameter para1, SqlParameter para2)
        {
            SqlParameter[] para = new SqlParameter[2];
            para[0] = para1;
            para[1] = para2;
            string sqlcmd = "Insert into CarInfo Values(@UserName,@CarNum)";
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
        /// <summary>
        /// 添加车辆信息
        /// </summary>
        /// <param name="name">用户名</param>
        /// <param name="carnum">车牌号</param>
        /// <returns></returns>
        public bool AddCar(string name, string carnum)
        {
            SqlParameter[] para = new SqlParameter[2];
            para[0] = new SqlParameter("@UserName", name);
            para[1] = new SqlParameter("@CarNum", carnum);
            string sqlcmd = "Insert into CarInfo Values(@UserName,@CarNum)";
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
