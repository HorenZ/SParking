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
    public partial class UserPages : System.Web.UI.Page
    {
        private UserInfo nowuser;
        private List<string> listcarinfo;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                if (Session["UserInfo"]==null)
                {
                    Response.Write(Helper.jsPrint("登录信息过期，请从新登陆！"));
                    //Response.Redirect("Login.aspx",true);
                    return;
                }
                nowuser= Session["UserInfo"] as UserInfo;
                listcarinfo = new CarInfoBLL().GetUserCarInfo(nowuser);
                this.lbUsername.Text = nowuser.UserName;
                InitRBL();
                string mode = Request.QueryString["mode"];
                if (mode=="1")
                {
                    
                }
            }
        }
        /// <summary>
        /// 为单选框绑定数据
        /// </summary>
        private void InitRBL()
        {
            //为空（没有添加车辆）不显示单选框
            if (listcarinfo.Count==0)
            {
                this.RBLCarInfo.Visible = false;
                return;
            }

            this.RBLCarInfo.DataSource = listcarinfo;

            this.RBLCarInfo.DataBind();
        }

        private void InitUserState()
        {
            UserState state=Session["UserState"] as UserState;
            this.lbMoney.Text = state.UserMoney.ToString() + "￥";
            if (state.UserMoney>=0)
            {
                this.btnStatr2.Text = "正常";
            }
            else
            {
                this.btnStatr2.Text = "冻结";
            }
        }

        //protected void Timer1_OnTick(object sender, EventArgs e)
        //{
        //    DateTime dt = DateTime.Now;
        //    //年月日
        //    string t1 = dt.ToLongDateString().ToString();
        //    //时间
        //    string t2 = dt.ToLongTimeString().ToString();
        //    this.lbTimeNow.Text = string.Format("今天是{0} 当前时间为：{1}", t1, t2);
        //}

        protected void btnUpdate_OnClick(object sender, EventArgs e)
        {
            string OldPWD = this.txbOldPwd.Text.Trim();
            string NewPWD = this.txbNewPwd.Text.Trim();
            if (Helper.YzNameandPwd(OldPWD,NewPWD)!=2)
            {
                this.lbUpdataMsg.Text = "密码格式错误！";
            }
            UserInfoBLL bll=new UserInfoBLL();
            if (bll.UpdataPWD((Session["UserInfo"] as UserInfo).UserName,NewPWD))
            {
                Helper.jsPrint("密码修改成功！");
                return;
            }

            Helper.jsPrint("密码修改失败！");
        }

        protected void RBLCarInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.btnDelete.Visible = true;
            this.btnUpdatacar.Visible = true;

        }

        protected void btnDelete_OnClick(object sender, EventArgs e)
        {
            string deleteCarnum = this.RBLCarInfo.SelectedItem.Text;
            //调用方法进行删除
            if (new CarInfoBLL().DeleteCar((Session["UserInfo"] as UserInfo).UserName,deleteCarnum))
            {
                Helper.jsPrint("删除成功！");
                InitRBL();
                return;
            }

            Helper.jsPrint("删除失败！");
        }

        protected void btnNewCar_OnClick(object sender, EventArgs e)
        {
            //判断绑定车辆数是否超出最大上限
            if (new CarInfoBLL().GetUserCarInfo(Session["UserInfo"] as UserInfo).Count>=5)
            {
                Helper.jsPrint("每个账号最多绑定5辆汽车！");
                return;
            }
            //隐藏信息div显示新建div
            this.pManager.Visible = false;
            this.paddCar.Visible = true;
        }

        protected void btnSaveCar_OnClick(object sender, EventArgs e)
        {
            //准备参数
            string carNum = this.txbcarNum.Text.Trim();
            CarInfoBLL bll=new CarInfoBLL();
            //调用方法保存车辆
            if (bll.AddCar((Session["UserInfo"] as UserInfo).UserName, carNum))
            {
                Helper.jsPrint("保存成功！");
                this.paddCar.Visible = false;
                this.pManager.Visible = true;
            }
            else
            {
                Helper.jsPrint("保存失败！");
            }
            
            
        }
        
        protected void btnExit_OnClick(object sender, EventArgs e)
        {
            this.txbcarNum.Text = "";
            this.paddCar.Visible = false;
            this.pManager.Visible = true;
        }

        protected void btnUpdatacar_OnClick(object sender, EventArgs e)
        {
            this.pManager.Visible = false;
            this.pUpdataCar.Visible = true;
            this.lbOldCarNum.Text = this.RBLCarInfo.SelectedItem.Text; 
        }

        protected void btnExit2_OnClick(object sender, EventArgs e)
        {
            this.pUpdataCar.Visible = false;
            this.pManager.Visible = true;
            this.txbNewCarNum.Text = "";
        }
        /// <summary>
        /// 修改后保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnUpdataCarNum_Click(object sender, EventArgs e)
        {

        }
    }
}