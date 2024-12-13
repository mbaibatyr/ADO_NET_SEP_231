using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace MySQLClient
{
    public class Program
    {
        static string conStr = "Server=206-P;Database=DB;Trusted_Connection=True;TrustServerCertificate=true";
        static string conStr2 = "Server=206-P;Database=DB;User Id=user1;Password=1234;TrustServerCertificate=True;";

        static void Main()
        {
            //TestConnection();
            //Console.WriteLine(GetDate());
            SelectFromTable2();
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

        static void SelectFromTable()
        {
            using (SqlConnection db = new SqlConnection(conStr))
            {
                db.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM City", db))
                {
                    var dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                        while (dr.Read())
                        {
                            Console.WriteLine($"{dr["id"].ToString()} - {dr["name"].ToString()}  - {dr["date_birth"].ToString()}");
                        }
                }
                db.Close();
            }
        }

        static void SelectFromTable2()
        {
            using (SqlConnection db = new SqlConnection(conStr))
            {
                db.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM City", db))
                {
                    DataTable dt = new DataTable();
                    dt.Load(cmd.ExecuteReader());
                    Console.WriteLine($"ROWS: {dt.Rows.Count} COLUMNS: {dt.Columns.Count}");
                    foreach (DataRow row in dt.Rows)
                    {
                        Console.WriteLine($"{row["id"].ToString()} - {row["name"].ToString()}  - {row["date_birth"].ToString()}");
                    }
                        
                }
                db.Close();
            }
        }
    }
}