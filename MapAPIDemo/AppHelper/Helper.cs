using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MapAPIDemo.AppHelper
{
    public class Helper
    {
        /// <summary>
        /// 验证用户名和密码是否合法
        /// </summary>
        /// <param name="username"></param>
        /// <param name="pwd"></param>
        /// <returns>
        /// 0:为空
        /// 1:长度不足
        /// 2:正常
        /// </returns>
        public static int YzNameandPwd(string username, string pwd)
        {
            if (username == "" || pwd == "")
            {
                return 0;
            }

            if (username.Length < 4 ||pwd.Length<4)
            {
                return 1;
            }

            return 2;
        }

        /// <summary>
        /// alert弹出消息框
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string jsPrint(string str)
        {
            return "<script type='text/javascript'>alert('" + str + "')</script>";
        }
    }
}