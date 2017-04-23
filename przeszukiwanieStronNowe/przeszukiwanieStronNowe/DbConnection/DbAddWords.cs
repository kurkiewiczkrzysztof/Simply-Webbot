using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace przeszukiwanieStronNowe.DbConnection
{
    public class DbAddWords
    {
        public static void AddWord(SqlConnection conn, string url, string[] array)
        {
            conn.Open();
            try
            {
                SqlCommand command;
                foreach (string v in array)
                {
                    string sprawdz = "select count (*) from Slowa where Tresc = @param";
                    command = new SqlCommand(sprawdz, conn);
                    command.Parameters.Add("@param", SqlDbType.NVarChar, 300).SqlValue = v;
                    int sprawdzIle = (int)command.ExecuteScalar();
                    //Console.WriteLine("Sprawdz Ile Slow: " + sprawdzIle);
                    if (sprawdzIle == 0)
                    {
                        string sql = "INSERT INTO Slowa(Tresc) VALUES(@param2)";
                        SqlCommand cmd = new SqlCommand(sql, conn);
                        cmd.Parameters.Add("@param2", SqlDbType.VarChar, 50).SqlValue = v;
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                        try
                        {
                            string queryForIdStrony = "Select IdStrony from Strony WHERE Adres=@param3";
                            string queryForIdSlowa = "Select IdSlowa from Slowa WHERE Tresc=@param4";
                            int IdStrony = 0, IdSlowa = 0;
                            SqlCommand cmd4 = new SqlCommand(queryForIdStrony, conn);
                            cmd4.Parameters.Add("@param3", SqlDbType.VarChar).SqlValue = url;
                            IdStrony = (int)cmd4.ExecuteScalar();
                            SqlCommand cmd5 = new SqlCommand(queryForIdSlowa, conn);
                            cmd5.Parameters.Add("@param4", SqlDbType.VarChar).SqlValue = v;
                            IdSlowa = (int)cmd5.ExecuteScalar();
                            //Console.WriteLine(IdStrony + " " + IdSlowa);
                            DbCombineUrlWithWords.DbCombineUrlWithWordss(conn, IdStrony, IdSlowa);
                        }
                        catch (NullReferenceException)
                        {
                            Console.WriteLine("Problem ze slowem: " + v);
                        }
                    }
                }
            }catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            conn.Close();
        }
    }
}
