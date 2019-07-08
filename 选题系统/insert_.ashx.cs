using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using MODEL;
using BLL;
using System.Data;
using System.Web.SessionState;
namespace 选题系统
{
    /// <summary>
    /// insert 的摘要说明
    /// </summary>
    public class insert : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            ////List<Teacher> json_item = new List<Teacher>();
            //接受前台ajax传输过来的数据 取到学生的学号  看学生添加的选题数量是不是到达最大
            if (context.Session["id"] == null)
            {
                context.Response.Write("nologin");
            }
            else
            {
                string stu_num = context.Request["name"];
                int insert_count = Convert.ToInt32(context.Request["count"]);
                int count = stu_project_count(stu_num);
                if ((count + insert_count) >= 1)
                {
                    context.Response.Write("false");
                }
                else
                {
                    string json_ = context.Request["data"];
                    context.Response.ContentType = "text/plain";
                    List<stu_insert> json_item = JsonConvert.DeserializeObject<List<stu_insert>>(json_);
                    if (json_item.Count > 1)
                    {
                        context.Response.Write("false");
                    }
                    else
                    {
                        foreach (var item in json_item)
                        {
                            BLL.stuBll.insert_pro(item);
                        }
                        stu_insert s = new stu_insert();
                        //BLL.stuBll.updateIsYes()
                        context.Response.Write("true");
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
        public static int stu_project_count(string stu_num) {
            stu_insert stu_Insert = new stu_insert
            {
                stu_num = stu_num
            };
            DataSet ds = BLL.stuBll.select_project_count(stu_Insert);
            int count = ds.Tables[0].Rows.Count;
            return count;
        }
    }
}