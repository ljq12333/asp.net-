using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
namespace 选题系统
{
    /// <summary>
    /// _out 的摘要说明
    /// </summary>
    public class _out : IHttpHandler ,IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            if (context.Request["url"].ToString().Trim() == "teacher")
            {
                context.Session["tea_id"] = null;
                context.Session["tea_name"] = null;
                context.Response.ContentType = "text/plain";
                context.Response.Write("退出成功");
            }
            else
            {
                context.Session["name"] = null;
                context.Session["id"] = null;
                context.Response.ContentType = "text/plain";
                context.Response.Write("退出成功");
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