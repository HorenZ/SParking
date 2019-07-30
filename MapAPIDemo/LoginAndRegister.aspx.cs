using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;

namespace MapAPIDemo
{
    public partial class LoginAndRegister : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Register(object sender, EventArgs e)
        {
            this.panLogin.Visible = false;
            this.PanRegister.Visible = true;
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            //UserInfoBLL bll = new UserInfoBLL();
            //UserInfo user = new UserInfo()
            //{
            //    carNum = this.txbCarNumber.Text.Trim(),
            //    Pwd = this.txbPwdRe.Text.Trim(),
            //    root = 0,
            //    UserName = this.txbUnameRe.Text.Trim()
            //};
            //string result = bll.Register(user);
            //this.lbMsg.Text = result;

            ////跳转未完成！


        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            //UserInfoBLL bll = new UserInfoBLL();
            //if (bll.LoginUser(this.txbUName.Text.Trim(),this.txbPWD.Text))
            //{
            //    this.lbMsg1.Text = "登录成功！";
            //    //保存session
            //    Session["UserName"] = this.txbUName.Text;
            //    //跳转未完成

            //}
            //else
            //{
            //    this.lbMsg1.Text = "密码错误！";
            //}
        }
    }
}