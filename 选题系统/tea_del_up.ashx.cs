using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MODEL;
using System.Web.SessionState;
namespace 选题系统
{
    /// <summary>
    /// tea_del_up 的摘要说明
    /// </summary>
    public class tea_del_up : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            if (context.Session["tea_id"] == null)
            {
                context.Response.Write("nologin");
            }
            else
            {
                if (context.Request["status"] == "del")
                {
                    project project = new project()
                    {
                        teacher_num = context.Request["tea_num"],
                        project_name = context.Request["project_name"],
                    };
                    if (BLL.stuBll.tea_del_project(project) == true)
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
                else
                {
                    project project = new project()
                    {
                        teacher_num = context.Request["tea_num"],
                        project_name = context.Request["project_name"],
                        project_info = context.Request["project_info"]
                    };
                    if (BLL.stuBll.tea_update_project(project) == true)
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