using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MapAPIDemo.Master
{
    public partial class test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void s23s_OnClick(object sender, EventArgs e)
        {
            this.b111.Visible = true;
            this.a222.Visible = false;
        }
    }
}