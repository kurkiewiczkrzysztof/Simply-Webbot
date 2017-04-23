using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace przeszukiwanieStronNowe.DbConnection
{
    public class DbCombineUrlWithWords
    {
        public static void DbCombineUrlWithWordss(SqlConnection conn, int idStrony, int idSlowa)
        {
            try
            {
                    string query = "INSERT INTO Strona_Slowa (IdStrony,IdSlowa)  Values (@param1,@param2)";
                    SqlCommand command = new SqlCommand(query, conn);
                    command.Parameters.Add("@param1", SqlDbType.Int).SqlValue = idStrony;
                    command.Parameters.Add("@param2", SqlDbType.Int).SqlValue = idSlowa;

                    command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
