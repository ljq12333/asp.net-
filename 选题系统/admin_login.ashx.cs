using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MODEL;
namespace 选题系统
{
    /// <summary>
    /// tea_login 的摘要说明
    /// </summary>
    public class tea_login : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            admin admin = new admin()
            {
                username = context.Request["username"],
                pwd = context.Request["pwd"]
            };
            if (BLL.stuBll.login_tea(admin).Tables[0].Rows.Count > 0)
            {
                context.Response.ContentType = "text/plain";
                context.Response.Write("true");
            }
            else {
                context.Response.ContentType = "text/plain";
                context.Response.Write("false");
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}