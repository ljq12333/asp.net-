using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace 选题系统
{
    /// <summary>
    /// selecAll 的摘要说明
    /// </summary>
    public class selecAll : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string jsonstr = selectall();
            if (jsonstr == "false")
            {
                jsonstr = "";
                context.Response.ContentType = "text/plain";
                context.Response.Write(jsonstr);
            }
            else {
                context.Response.ContentType = "text/plain";
                context.Response.Write(jsonstr);
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
        public static string selectall() {
            string connstr = "Initial Catalog=Music;Persist Security Info=True;User ID=sa;Password=lijianqiang1998";
            SqlConnection conn = new SqlConnection(connstr);
            SqlCommand cmd = new SqlCommand("select top(2) tea_name, project_name,project_info from project where IsChoose='否'", conn);
            DataSet ds = new DataSet();
            SqlDataAdapter sqlData = new SqlDataAdapter(cmd);
            sqlData.Fill(ds);
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
                            if (i == ds.Tables[0].Rows.Count-1)
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