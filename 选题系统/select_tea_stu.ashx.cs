using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace 选题系统
{
    /// <summary>
    /// select_tea_stu 的摘要说明
    /// </summary>
    public class select_tea_stu : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            if (context.Request["status"] == "tea")
            {
                DataSet ds = BLL.stuBll.selectAll_tea();
                StringBuilder json_ = new StringBuilder();
                if (ds.Tables[0].Rows.Count > 0)
                {
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
                    context.Response.Write("");
                }
            }
            else
            {
                DataSet ds = BLL.stuBll.selectAll_stu();
                StringBuilder json_ = new StringBuilder();
                json_.Append("[");
                if (ds.Tables[0].Rows.Count > 0)
                {
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
                    context.Response.Write("");
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