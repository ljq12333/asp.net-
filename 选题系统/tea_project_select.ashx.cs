using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 选题系统
{
    /// <summary>
    /// tea_project_select 的摘要说明
    /// </summary>
    public class tea_project_select : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("Hello World");
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