using Microsoft.Data.SqlClient;
using System;

namespace MySQLClient
{
    public class Program
    {
        static string conStr = "Server=206-P;Database=testDB;Trusted_Connection=True;TrustServerCertificate=true";
        static string conStr2 = "Server=206-P;Database=testDB;User Id=user1;Password=1234;TrustServerCertificate=True;";

        static void Main()
        {
            //TestConnection();
            Console.WriteLine(GetDate());
        }

        static string GetDate()
        {
            string result = null;
            using (SqlConnection db = new SqlConnection(conStr2))
            {
                db.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT GETDATE()", db))
                {
                    var ob = cmd.ExecuteScalar();
                    if (ob != null)
                        result = ob.ToString();
                }
                db.Close();
            }
            return result;
        }

        static void TestConnection()
        {
            //using (SqlConnection db = new SqlConnection(conStr))
            using (SqlConnection db = new SqlConnection(conStr2))
            {
                Console.WriteLine(db.State.ToString());
                db.Open();
                Console.WriteLine(db.State.ToString());
                db.Close();
                Console.WriteLine(db.State.ToString());
            }
        }
    }
}