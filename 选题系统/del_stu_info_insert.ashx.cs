using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MODEL;
namespace 选题系统
{
    /// <summary>
    /// del_stu_info_insert 的摘要说明
    /// </summary>
    public class del_stu_info_insert : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string stu_num = context.Request["stu_num"];
            stu_insert stu_Insert = new stu_insert()
            {
                stu_num = stu_num
            };
            if (BLL.stuBll.del_stu_info_insert(stu_Insert) == true)
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