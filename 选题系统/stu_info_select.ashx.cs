using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using MODEL;
using System.Web.SessionState;
namespace 选题系统
{
    /// <summary>
    /// stu_info_select 的摘要说明
    /// </summary>
    public class stu_info_select : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            if (context.Session["id"] == null)
            {
                context.Response.Write("nologin");
            }
            else
            {
                stu_insert stu_Insert = new stu_insert()
                {
                    stu_num = context.Request["stu_num"]
                };
                if (BLL.stuBll.select_stuinfo(stu_Insert).Tables[0].Rows.Count > 0)
                {
                    DataSet ds = BLL.stuBll.select_stuinfo(stu_Insert);
                    StringBuilder json_ = new StringBuilder();
                    json_.Append("[");
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        json_.Append("{");
                        for (int j = 0; j < ds.Tables[0].Columns.Count; j++)
                        {
                            if (j != ds.Tables[0].Columns.Count - 1)
                            {
                                json_.Append("\"" + ds.Tables[0].Columns[j].ToString() + "\":\"" + ds.Tables[0].Rows[i][j].ToString() + "\",");

                            }
                            else
                            {
                                if (i == ds.Tables[0].Rows.Count - 1)
                                {
                                    json_.Append("\"" + ds.Tables[0].Columns[j].ToString() + "\":\"" + ds.Tables[0].Rows[i][j].ToString() + "\"}");
                                }
                                else
                                {
                                    json_.Append("\"" + ds.Tables[0].Columns[j].ToString() + "\":\"" + ds.Tables[0].Rows[i][j].ToString() + "\"},");
                                }
                            }
                        }
                    }
                    json_.Append("]");
                    context.Response.ContentType = "text/plain";
                    context.Response.Write(json_);
                }
                else
                {
                    context.Response.ContentType = "text/plain";
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