using Model;
using System;
using System.Collections.Generic;
using System.Text;
using DAL;

namespace BLL
{
    public class UserInfoBLL
    {
        UserInfoDAL dal=new UserInfoDAL();
        /// <summary>
        /// 注册用户
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public string Register(UserInfo userInfo)
        {
            int e = dal.AddUser(userInfo);
            switch (e)
            {
                case 0:
                    return "注册失败！";
                case 1:
                    return "注册成功，但车辆添加失败！";
                case 2:
                    return "注册成功！";
                case 3:
                    return "注册成功！请稍后到个人中心添加车辆信息！";
                case 4:
                    return "用户名重复！";
            }


            return null;

        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <returns></returns>
        public UserInfo LoginUser(string name)
        {
            return dal.LoginUser(name);
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="name">用户名</param>
        /// <param name="newPwd">新密码</param>
        /// <returns></returns>
        public bool UpdataPWD(string name, string newPwd)
        {
            return dal.UpdataPWD(name, newPwd);
        }
    }
}
