using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MODEL;
namespace 选题系统
{
    /// <summary>
    /// insert1 的摘要说明
    /// </summary>
    public class insert1 : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            if (context.Request["status"]=="stu")
            {
                student student = new student()
                {
                    stu_num = context.Request["stu_num"],
                    stu_name = context.Request["stu_name"],
                    pwd = context.Request["pwd"],
                    className = context.Request["class_name"]
                };
                if (BLL.stuBll.insert_stu(student) == true)
                {
                    context.Response.ContentType = "text/plain";
                    context.Response.Write("true");
                }
                else {
                    context.Response.Write("false");
                }
            }
            else {
                Teacher teacher = new Teacher()
                {
                    teacher_name = context.Request["tea_name"],
                    teacher_num = context.Request["tea_num"],
                    pwd = context.Request["pwd"]
                };
                if (BLL.stuBll.insert_tea(teacher) == true)
                {
                    context.Response.ContentType = "text/plain";
                    context.Response.Write("true");
                }
                else {
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