using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
   public class sqlHeleper
    {
        public static string conn = "Initial Catalog=Music;Persist Security Info=True;User ID=sa;Password=lijianqiang1998";
        public static bool all (string sql) {
            SqlConnection sqlconn = new SqlConnection(conn);
            try
            {
                sqlconn.Open();
                SqlCommand cmd = new SqlCommand(sql, sqlconn);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                return false;
            }
            finally
            {
                sqlconn.Close();
            }
        }
        public static DataSet selectAll(string sql) {
            SqlConnection sqlconn = new SqlConnection(conn);
            sqlconn.Open();
            SqlCommand cmd = new SqlCommand(sql, sqlconn);
            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(ds);
            return ds;
        }
    }
}