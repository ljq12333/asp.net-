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
    /// tea_select 的摘要说明
    /// </summary>
    public class tea_select : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //string tea= context.Response[""]
            project project = new project()
            {
                teacher_num = context.Request["tea_num"]
            };
            StringBuilder jsonStr = new StringBuilder();
            jsonStr.Append("[");
            DataSet ds = BLL.stuBll.tea_select_project(project);
            if (ds.Tables[0].Rows.Count > 0)
            {
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
            else
            {
                context.Response.ContentType = "text/plain";
                context.Response.Write("");
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