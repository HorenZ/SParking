using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Model;

namespace DAL
{
    public class UserStateDAL
    {
        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="state"></param>
        public void SetupState(UserState state)
        {
            SqlParameter[] paras = new SqlParameter[3];
            paras[0] = new SqlParameter("@UserName", state.UserName);
            paras[1] = new SqlParameter("@State", state.State);
            paras[2] = new SqlParameter("@UserMoney", state.UserMoney);
            string sqlcmd = "Insert into UserState Values(@UserName,@State,@UserMoney)";
            SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString,
                CommandType.Text,
                sqlcmd,
                paras);
        }
        /// <summary>
        /// 获取用户的状态信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public UserState GetUserState(UserInfo user)
        {
            //准备参数
            SqlParameter para=new SqlParameter("@UserName",user.UserName);
            string sqlcmd = "Select * From UserState Where UserName=@UserName";
            SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString,
                CommandType.Text,
                sqlcmd,
                para);
            UserState state = null;
            while (reader.Read())
            {
                state=new UserState();
                state.UserName = reader["UserName"].ToString();
                state.State = Convert.ToBoolean(reader["State"]);
                state.UserMoney = Convert.ToDecimal(reader["UserMoney"]);
                break;
            }

            return state;
        }

        public bool AddMoney(string username, decimal money)
        {
            SqlParameter[] paras=new SqlParameter[2];
            paras[0]=new SqlParameter("@UserName",username);
            paras[1]=new SqlParameter("@UserMoney",money);
            string sqlcmd = "Update UserState set UserMoney=@UserMoney Where UserName=@UserName";
            int i = SqlHelper.ExecuteNonQuery(
                SqlHelper.ConnectionString,
                CommandType.Text,
                sqlcmd,
                paras);
            if (i==0)
            {
                return true;
            }

            return false;
        }
    }
}
