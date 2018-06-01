using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setter
{
    class DbConnection
    {

        // database name was not defined

        SqlConnection cn = new SqlConnection(@"Data Source=DESKTOP-PLSJROU\SIMANT;Initial Catalog=Hains;Integrated Security=True");
        // SqlConnection cn = new SqlConnection(myconnString);
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();

        //insert update delete
        public void manipulate(string query)
        {
            cn.Open();
            cmd.Connection = cn;
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        //select
        public DataTable retrieve(string query)
        {
            DataSet ds = new DataSet();
            da = new SqlDataAdapter(query, cn);

            // dot semi-colon error

            da.Fill(ds);
            return ds.Tables[0];
        }
    }
}