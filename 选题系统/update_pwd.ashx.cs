using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MODEL;
namespace 选题系统
{
    /// <summary>
    /// update_pwd 的摘要说明
    /// </summary>
    public class update_pwd : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            student student = new student()
            {
                stu_num = context.Request["stu_num"],
                pwd = context.Request["pwd"]
            };
            if (BLL.stuBll.update_pwd(student) == true)
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

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}