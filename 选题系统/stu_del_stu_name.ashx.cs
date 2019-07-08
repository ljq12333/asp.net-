using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MODEL;
using System.Web.SessionState;
namespace 选题系统
{
    /// <summary>
    /// stu_del_stu_name 的摘要说明
    /// </summary>
    public class stu_del_stu_name : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            if (context.Session["tea_id"] == null)
            {
                context.Response.Write("nologin");
            }
            else
            {
                stu_insert stu_Insert = new stu_insert()
                {
                    project_name = context.Request["project_name"]
                };
                if (BLL.stuBll.stu_del_projectName(stu_Insert) == true)
                {
                    context.Response.ContentType = "text/plain";
                    context.Response.Write("true");
                }
                else
                {
                    context.Response.ContentType = "text/plain";
                    context.Response.Write("false");
                }
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