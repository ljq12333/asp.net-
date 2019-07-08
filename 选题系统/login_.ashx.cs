using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using MODEL;
namespace 选题系统
{
    /// <summary>
    /// login1 的摘要说明
    /// </summary>
    public class login1 : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            string status = context.Request["status"];
            if (status.Trim() == "学生")
            {
                student student = new student()
                {
                    stu_num = context.Request["id"],
                    pwd = context.Request["pwd"],
                };
                DataSet ds = BLL.stuBll.select_stu_pwd(student);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataSet ds1 = BLL.stuBll.select_stu_name(student);                   
                    context.Session["id"] = context.Request["id"];
                    context.Session["name"] = ds1.Tables[0].Rows[0][0].ToString();
                    context.Response.ContentType = "text/plain";
                    //context.Response.Redirect("index.aspx");
                    context.Response.Write("index_true");
                }
                else {
                    context.Response.Write("false");
                }
            }
            else {
                Teacher teacher = new Teacher()
                {
                    teacher_num = context.Request["id"],
                    pwd = context.Request["pwd"],
                };
                DataSet ds = BLL.stuBll.select_teacher_pwd(teacher);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataSet ds1 = BLL.stuBll.select_tea_name(teacher);
                    context.Session["tea_id"] = context.Request["id"];
                    context.Session["tea_name"] = ds1.Tables[0].Rows[0][0].ToString().Trim();
                    context.Response.ContentType = "text/plain";
                    //context.Response.Write("TeacherIndex.aspx");
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