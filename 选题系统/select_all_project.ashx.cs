using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace 选题系统
{
    /// <summary>
    /// select_all_project 的摘要说明
    /// </summary>
    public class select_all_project : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string json_ = selectall();
            if (json_ == "false")
            {
                json_ = "";
                context.Response.ContentType = "text/plain";
                context.Response.Write(json_);
            }
            else {
                context.Response.ContentType = "text/plain";
                context.Response.Write(json_);
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
        public static string selectall()
        {
            string connstr = "Initial Catalog=Music;Persist Security Info=True;User ID=sa;Password=lijianqiang1998";
            SqlConnection conn = new SqlConnection(connstr);
            SqlCommand cmd = new SqlCommand("select tea_name, project_name,project_info from project where IsChoose='否'", conn);
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
    }
}