using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL
{
    public class UserInfoDAL
    {
        /// <summary>
        /// 注册用户///
        /// 0：注册用户失败//
        /// 1：注册用户成功但添加车辆信息错误//
        /// 2：注册成功//
        /// 3：未添加车辆信息注册成功//
        /// 4：用户名重复
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns>
        /// 0：注册用户失败
        /// 1：注册用户成功但添加车辆信息错误
        /// 2：注册成功
        /// 3：未添加车辆信息注册成功
        /// 4：用户名重复
        /// </returns>
        public int AddUser(UserInfo userInfo)
        {
            //判断用户名是否重复
            SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString,
                CommandType.Text,
                "select Count(UserName) From UserInfo Where UserName='" + userInfo.UserName+"'");
            while (reader.Read())
            {
                if (reader[0].ToString()=="1")
                {
                    return 4;
                }
            }

            //准备参数
            SqlParameter[] para=new SqlParameter[5];
            para[0]=new SqlParameter("@UserName",userInfo.UserName);
            para[1]=new SqlParameter("@PWD",userInfo.Pwd);
            para[2]=new SqlParameter("@root",userInfo.root);
            para[3]=new SqlParameter("@carNum",userInfo.carNum);
            para[4]=new SqlParameter("@PhoneNumber",userInfo.phone);
            string sqlcmd = "Insert into UserInfo Values(@UserName,@PWD,@root,@PhoneNumber)";
            int e = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString,
                CommandType.Text,
                sqlcmd,
                para
            );
           new UserStateDAL().SetupState(new UserState()
            {
                State = true,
                UserName = userInfo.UserName,
                UserMoney = 0
            });
            if (e==0)
            {
                return 0;
            }
            //添加车辆信息
            if (userInfo.carNum!=null)
            {
                if (new CarInfoDAL().AddCar(para[0],para[3]))
                {
                    return 2;
                }

                return 1;
            }

            return 3;
        }

        

        ///// <summary>
        ///// 添加车辆信息
        ///// </summary>
        ///// <param name="para1"></param>
        ///// <param name="para2"></param>
        ///// <returns>
        ///// true:成功
        ///// false:失败
        ///// </returns>
        //private bool AddCar(SqlParameter para1, SqlParameter para2)
        //{
        //    SqlParameter[] para = new SqlParameter[2];
        //    para[0] = para1;
        //    para[1] = para2;
        //    string sqlcmd = "Insert into CarInfo Values(@UserName,@CarNum)";
        //    int e = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString,
        //        CommandType.Text,
        //        sqlcmd,
        //        para
        //    );
        //    if (e==0)
        //    {
        //        return false;
        //    }

        //    return true;
        //}
        ///// <summary>
        ///// 添加车辆信息
        ///// </summary>
        ///// <param name="name">用户名</param>
        ///// <param name="carnum">车牌号</param>
        ///// <returns></returns>
        //public bool AddCar(string name,string carnum)
        //{
        //    SqlParameter[] para = new SqlParameter[2];
        //    para[0] = new SqlParameter("@UserName",name);
        //    para[1] = new SqlParameter("@CarNum",carnum);
        //    string sqlcmd = "Insert into CarInfo Values(@UserName,@CarNum)";
        //    int e = SqlHelper.ExecuteNonQuery(SqlHelper.ConnectionString,
        //        CommandType.Text,
        //        sqlcmd,
        //        para
        //    );
        //    if (e == 0)
        //    {
        //        return false;
        //    }

        //    return true;
        //}

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="name">用户名</param>
        /// <returns>登录密码</returns>
        public UserInfo LoginUser(string name)
        {
            UserInfo userInfo = null;
            SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionString,
                CommandType.Text,
                "select * From UserInfo Where UserName=@UserName",
                new SqlParameter("@UserName", name));
            while (reader.Read())
            {
                userInfo=new UserInfo();
                userInfo.UserName = reader["UserName"].ToString();
                userInfo.Pwd = reader["Pwd"].ToString();
                userInfo.phone = reader["phone"].ToString();
                userInfo.root = Convert.ToInt32(reader["root"]);
                break;
            }

            return userInfo;
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="name">用户名</param>
        /// <param name="newPwd">新密码</param>
        /// <returns></returns>
        public bool UpdataPWD(string name, string newPwd)
        {
            SqlParameter[] paras=new SqlParameter[2];
            paras[0] = new SqlParameter("@UserName", name);
            paras[1] = new SqlParameter("@Password", newPwd);
            string sqlcmd = "Update UserInfo set Pwd=@Password where UserName=@UserName";
            int a = SqlHelper.ExecuteNonQuery(
                SqlHelper.ConnectionString,
                CommandType.Text,
                sqlcmd,
                paras
            );
            if (a==1)
            {
                return true;
            }

            return false;
        }
    }
}
