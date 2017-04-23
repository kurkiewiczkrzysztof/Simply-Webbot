using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace przeszukiwanieStronNowe.DbConnection
{
    public class DbConnection
    {
        public static SqlConnection Polacz()
        {
            SqlConnection conn = new SqlConnection();
            string stringconn = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=c:\users\user\documents\visual studio 2013\Projects\przeszukiwanieStronNowe\przeszukiwanieStronNowe\App_Data\Baza.mdf;Integrated Security=True";
            conn.ConnectionString = stringconn;
            return conn;
        }
    }
}
