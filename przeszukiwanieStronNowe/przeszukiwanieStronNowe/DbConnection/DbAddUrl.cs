using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace przeszukiwanieStronNowe.DbConnection
{
    public class DbAddUrl
    {
        public static void AddUrl(SqlConnection conn, string url, bool contains)
        {
            conn.Open();
            try
            {
                string sprawdz = "select count (*) from Strony where Adres = @param";
                SqlCommand command = new SqlCommand(sprawdz, conn);
                command.Parameters.Add("@param", SqlDbType.VarChar, 300).SqlValue = url;
                int sprawdzIle = (int)command.ExecuteScalar();
                if (sprawdzIle == 0)
                {
                    string sql = "INSERT INTO Strony(Adres,Zawiera) VALUES(@param1,@param2)";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.Add("@param1", SqlDbType.VarChar, 300).SqlValue = url;
                    if (contains)
                    {
                        cmd.Parameters.Add("@param2", SqlDbType.Bit).SqlValue = 1;
                    }
                    else
                    {
                        cmd.Parameters.Add("@param2", SqlDbType.Bit).SqlValue = 0;
                    }
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Problem z URL: " + url);
            }
            conn.Close();
        }
    }
}
