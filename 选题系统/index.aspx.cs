using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace 选题系统
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] != null)
            {
                this.user.InnerText = Session["id"].ToString();
                this.nt.InnerText = Session["name"].ToString();
            }
            else {
                Response.Redirect("Alllogin.aspx");
            }
        }
    }
}