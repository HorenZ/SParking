using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MapAPIDemo.Master
{
    public partial class MasterLoginAndRegister : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public string SetHeadText
        {
            set { this.lbHeadText.Text = value; }
        }
    }
}