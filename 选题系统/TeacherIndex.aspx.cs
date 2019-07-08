using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace 选题系统
{
    public partial class teacher : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["tea_id"] != null)
            {
                this.teacher_id.InnerText = Session["tea_id"].ToString().Trim();
                this.nt.InnerText = Session["tea_name"].ToString().Trim();
            }
            else
            {
                Response.Redirect("Alllogin.aspx");
            }
        }
    }
}