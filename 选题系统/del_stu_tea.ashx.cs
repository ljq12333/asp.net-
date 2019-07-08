using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MODEL; 
namespace 选题系统
{
    /// <summary>
    /// del_stu_tea 的摘要说明
    /// </summary>
    public class del_stu_tea : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            if (context.Request["status"] == "stu")
            {
                student student = new student()
                {
                    stu_num = context.Request["num"]
                };
                if (DAL.stuDal.del_stu(student) == true)
                {
                    context.Response.ContentType = "text/plain";
                    context.Response.Write("true");
                }
                else {
                    context.Response.Write("false");
                }
            }
            else
            {
                Teacher teacher = new Teacher()
                {
                    teacher_num = context.Request["num"]
                };
                if (DAL.stuDal.del_tea(teacher) == true)
                {
                    DAL.stuDal.del_tea_pro(teacher);
                    project project = new project();
                    project.teacher_num = context.Request["num"];
                    DAL.stuDal.del_pro(project);
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