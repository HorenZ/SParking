﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using MapAPIDemo.AppHelper;
using Model;

namespace MapAPIDemo
{
    public partial class Index : System.Web.UI.Page
    {
        private UserInfo user = null;
        List<string> list=new List<string>();
        protected void Page_Load(object sender, EventArgs e)
        {
            

            if (!IsPostBack)
            {
                if (Session["UserInfo"] != null)
                {
                    user = Session["UserInfo"] as UserInfo;
                    this.lkbtn1.Text = user.UserName;
                    list = new CarInfoBLL().GetUserCarInfo(user);
                    if (list.Count == 1 && list[0]=="")
                    {
                        
                        this.rblCarNum.Visible = false;
                        this.lbmsgNoCar.Visible = true;
                        this.txbNewCar.Visible = true;
                        this.btnGotoport.Visible = false;
                        this.btnAddCar.Visible = true;
                    }
                    LoadUserCar(list);
                }
                string s2 = this.txbPortName.Value;
                //Response.Write(Helper.jsPrint(s2));
                //未登录
                if (Session["UserInfo"] as UserInfo == null)
                {
                    this.rblCarNum.Visible = false;
                    this.btnGotoport.Visible = false;
                    this.gotoLogin.Visible = true;
                }
                //未完成订单处理
                else
                {
                    if (new HistoryBLL().IsNoPayOrder((Session["UserInfo"] as UserInfo).UserName))
                    {
                        AppHelper.Helper.jsPrint("您还有未完成的订单，点击确定进入。");
                        Response.Redirect("UserPages.aspx?mdoe=1");
                    }
                }
            }

        }

        /// <summary>
        /// 加载用户车辆信息
        /// </summary>
        /// <param name="list"></param>
        private void LoadUserCar(List<string> listcar)
        {
            this.rblCarNum.DataSource = listcar;
            this.rblCarNum.DataBind();
            //绑定数据到Session
            Session["UserCarList"] = listcar;
        }

        protected void LoginAndRegister(object sender, EventArgs e)
        {
            //1.检查是否为登录状态
            if (Session["UserInfo"] as UserInfo == null)
            {
                //不为登录状态,进入登录界面
                Response.Redirect("Login.aspx",true);
                return;
            }
            //2.
            else
            {
                //已登录进入个人中心
                Response.Redirect("UserPages.aspx");
                return;
            }
            //3.
        }

        public string ReturnType()
        {
            List<PartInfo> list = PartInfoBLL.GetAllPartAddress();
            DataContractJsonSerializer json = new DataContractJsonSerializer(list.GetType());
            string szJson = "";
            using (MemoryStream stream = new MemoryStream())
            {
                json.WriteObject(stream, list);
                szJson = Encoding.UTF8.GetString(stream.ToArray());

            }

            return szJson;
        }

        protected void btnAddCar_OnClick(object sender, EventArgs e)
        {
            string carNum = this.txbNewCar.Text.Trim();
            CarInfoBLL bll=new CarInfoBLL();
            if (bll.AddCar((Session["UserInfo"] as UserInfo).UserName,carNum))
            {
                Helper.jsPrint("添加成功！");
                this.rblCarNum.Visible = true;
                this.lbmsgNoCar.Visible = false;
                this.btnAddCar.Visible = false;
                this.txbNewCar.Visible = false;
                this.btnGotoport.Visible = true;
                LoadUserCar(list);
                return;
            }
            Helper.jsPrint("添加失败!");
        }

        protected void btnGotoport_OnClick(object sender, EventArgs e)
        {
            //1、网页端申请车位 数据写入数据库 生成订单、活跃订单、
            //2、车库端3s / 次进行循环读取 读取完成再更改数据（分配的车位）
            //3、网页端等待1.5s后再次访问数据库失败则进行循环 使用try catch 防止同时读取 获取分配到的车位号
            string CarNum = this.rblCarNum.SelectedItem.Text;
            string parkName = this.txbPortName.Value;
            HistoryBLL historyBll = new HistoryBLL();
            //生成活跃订单
            ApplyInfo apply=new ApplyInfo();
            apply.HID = historyBll.GetNewHID()+1;
            apply.CarNum = CarNum;
            apply.ParkID = new PartInfoBLL().GetIdByName(parkName);
            apply.ParkPosintion = "null";
            apply.State = 0;
            if (new ApplyInfoBLL().CreateOrder(apply))
            {
                //保存失败
                AppHelper.Helper.jsPrint("出现了某些错误！(。・＿・。)ﾉI’m sorry~   错误代码:#APL01");
                return;
            }
            //生成历史订单
            History his=new History();
            his.UserName = (Session["UserInfo"] as UserInfo).UserName;
            his.BookTime = DateTime.Now;
            his.StartTime= Convert.ToDateTime("2000-1-1");
            his.EndTime = Convert.ToDateTime("2000-1-1");
            his.AllTime = Convert.ToDateTime("2000-1-1");
            his.CarNum = CarNum;
            his.PortName = parkName;
            his.PortPrice =Convert.ToDecimal(this.txbPrice.Value);
            his.State = -1;
            his.Cost = Convert.ToDecimal(0);
            his.ParkPosintion = "-1";
            if (historyBll.SaveHistory(his))
            {
                //保存失败
                AppHelper.Helper.jsPrint("出现了某些错误！(。・＿・。)ﾉI’m sorry~   错误代码:#HIS01");
                return;
            }
            
            //等待结果
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(1500);
                ApplyInfo apply_GetMsg = new ApplyInfoBLL().QueryOrderResult(historyBll.GetNewHID().ToString());
                //车位分配好
                if (apply_GetMsg.State == 1)
                {
                    //分配已完成 转移数据
                    if (historyBll.UpdateParkPosition(apply_GetMsg.ParkPosintion,apply_GetMsg.HID))
                    {
                        AppHelper.Helper.jsPrint("出现了某些错误！(。・＿・。)ﾉI’m sorry~   错误代码:#HIS02");
                        return;
                    }
                    //未完成 跳转到其他页面单独进行导航
                    AppHelper.Helper.jsPrint("OK");

                }
            }

        }

        protected void gotoLogin_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx",true);
        }
    }
}