using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MODEL;
using System.Data;
using System.Text;
namespace 选题系统
{
    /// <summary>
    /// tea_stu_select 的摘要说明
    /// </summary>
    public class tea_stu_select : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            Teacher teacher = new Teacher()
            {
                teacher_name = context.Request["tea_name"]
            };
            if (BLL.stuBll.select_teaName(teacher).Tables[0].Rows.Count > 0)
            {
                DataSet ds = BLL.stuBll.select_teaName(teacher);
                StringBuilder jsonStr = new StringBuilder();
                jsonStr.Append("[");
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    jsonStr.Append("{");
                    for (int j = 0; j < ds.Tables[0].Columns.Count; j++)
                    {
                        if (j != ds.Tables[0].Columns.Count - 1)
                        {
                            jsonStr.Append("\"" + ds.Tables[0].Columns[j].ToString() + "\":\"" + ds.Tables[0].Rows[i][j].ToString() + "\",");

                        }
                        else
                        {
                            if (i == ds.Tables[0].Rows.Count - 1)
                            {
                                jsonStr.Append("\"" + ds.Tables[0].Columns[j].ToString() + "\":\"" + ds.Tables[0].Rows[i][j].ToString() + "\"}");
                            }
                            else
                            {
                                jsonStr.Append("\"" + ds.Tables[0].Columns[j].ToString() + "\":\"" + ds.Tables[0].Rows[i][j].ToString() + "\"},");
                            }
                        }
                    }
                }
                jsonStr.Append("]");
                context.Response.ContentType = "text/plain";
                context.Response.Write(jsonStr.ToString());
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