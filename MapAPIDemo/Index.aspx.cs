using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
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
            History his=new History();
            his.UserName = (Session["UserInfo"] as UserInfo).UserName;
            his.StartTime=DateTime.Now;
            his.EndTime = Convert.ToDateTime("2000-1-1");
            his.AllTime = Convert.ToDateTime("2000-1-1");
            his.CarNum = this.rblCarNum.SelectedItem.Text;
            his.PortName = this.txbPortName.Value;
            his.PortPrice =Convert.ToDecimal(this.txbPrice.Value);
            his.State = Convert.ToBoolean(0);
            his.Cost = Convert.ToDecimal(0);
            new HistoryBLL().SaveHistory(his);
        }

        protected void gotoLogin_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx",true);
        }
    }
}