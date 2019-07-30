using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using MapAPIDemo.AppHelper;
using Model;

namespace MapAPIDemo
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Label lbtitle=Master.FindControl("lbHeadText") as Label;
                lbtitle.Text = "登录";
            }
        }

        protected void btnpost_OnClick(object sender, EventArgs e)
        {
            string username = this.txbUserName.Text.Trim();
            string pwd = this.txbPWD.Text.Trim();
            switch (Helper.YzNameandPwd(username,pwd))
            {
                case 0:
                    this.lbMsg.Text = "请输入用户名或密码！";
                    return;
                case 1:
                    this.lbMsg.Text = "用户名或密码格式错误!";
                    return;
                case 2:
                    break;
            }

            UserInfo userInfo = new UserInfoBLL().LoginUser(username);
            if (userInfo!=null)
            {
                //登陆成功
                Session["UserInfo"] = userInfo;
                Session["UserState"] = new UserStateBLL().GetUserState(userInfo);
                //跳转
                Response.Redirect("Index.aspx");
            }
        }

        protected void btnRegister_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }
    }
}