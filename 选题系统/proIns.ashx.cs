using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MODEL;
using System.Web.SessionState;
namespace 选题系统
{
    /// <summary>
    /// proIns 的摘要说明
    /// </summary>
    public class proIns : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            if (context.Session["tea_id"] == null)
            {
                context.Response.Write("nologin");
            }
            else
            {
                project project = new project()
                {
                    teacher_num = context.Request["teacher_id"],
                    teacher_name = context.Request["teacher_name"],
                    project_info = context.Request["project_info"],
                    project_name = context.Request["project_name"]
                };
                if (BLL.stuBll.tea_insert_project(project) == true)
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