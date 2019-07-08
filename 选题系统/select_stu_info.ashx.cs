using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;
using System.Text;
using System.Web.SessionState;
namespace 选题系统
{
    /// <summary>
    /// select_stu_info 的摘要说明
    /// </summary>
    public class select_stu_info : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            if (context.Session["id"] == null)
            {
                context.Response.Write("nologin");
            }
            else
            {
                string stu_num = context.Request["stu_num"];
                string json_ = selectall(stu_num);
                if (json_ == "false")
                {
                    json_ = "";
                    context.Response.ContentType = "text/plain";
                    context.Response.Write(json_);
                }
                else
                {
                    context.Response.ContentType = "text/plain";
                    context.Response.Write(json_);
                }
            }
        }
        public static string selectall(string stu_num)
        {
            string connstr = "Initial Catalog=Music;Persist Security Info=True;User ID=sa;Password=lijianqiang1998";
            SqlConnection conn = new SqlConnection(connstr);
            SqlCommand cmd = new SqlCommand("select * from stu_info where stu_num="+stu_num+"", conn);
            DataSet ds = new DataSet();
            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);
            sqlData.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
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
                return json_.ToString();
            }
            else {
                return "false";
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