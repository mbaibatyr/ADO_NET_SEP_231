using Microsoft.Data.SqlClient;
using System;

namespace MySQLClient
{ 
    public class Program
    {
        static string conStr = "Server=206-P;Database=testDB;Trusted_Connection=True;TrustServerCertificate=true";
        static void Main()
        {
            TestConnection();
        }

        static void TestConnection()
        {
            using (SqlConnection db = new SqlConnection(conStr))
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