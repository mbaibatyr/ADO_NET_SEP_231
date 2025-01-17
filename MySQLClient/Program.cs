using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;

namespace MySQLClient
{
    public class Program
    {
        public static IConfigurationRoot config;
        static string conStr = "Server=206-P;Database=DB;Trusted_Connection=True;TrustServerCertificate=true";
        static string conStr2 = "Server=206-P;Database=DB;User Id=user1;Password=1234;TrustServerCertificate=True;";

        static void Main()
        {
            config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            //Ado.Select();
            //Ado.SelectByName("о");
            //Ado.Insert("Актобе", 800000, new DateTime(1900, 01, 01));
            Ado.OutParameter();

            #region примеры вызовов
            //TestConnection();
            //Console.WriteLine(GetDate());
            //SelectFromTable2();
            //SelectFromProc();
            //SelectFromView();
            //SelectFromTableFunction();
            //InsertProc();
            //SelectFromProc();
<<<<<<< HEAD
            MultySet();
=======
            #endregion 
>>>>>>> 48f5524de5b6d0448da10854cbf235e745c51895
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
                    //Console.WriteLine($"ROWS: {dt.Rows.Count} COLUMNS: {dt.Columns.Count}");

                    var row2 = dt.Select("id = 2").FirstOrDefault();
                    if(row2 != null)
                        Console.WriteLine($"{row2["id"].ToString()} - {row2["name"].ToString()}  - {row2["date_birth"].ToString()}");

                    foreach (DataRow row in dt.Rows)
                    {
                        Console.WriteLine($"{row["id"].ToString()} - {row["name"].ToString()}  - {row["date_birth"].ToString()}");
                    }

                }
                db.Close();
            }
        }

        static void SelectFromProc()
        {
            using (SqlConnection db = new SqlConnection(conStr))
            {
                db.Open();
                using (SqlCommand cmd = new SqlCommand("pCity;2", db))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable();
                    dt.Load(cmd.ExecuteReader());
                    //Console.WriteLine($"ROWS: {dt.Rows.Count} COLUMNS: {dt.Columns.Count}");

                    var row2 = dt.Select("id = 2").FirstOrDefault();
                    if (row2 != null)
                        Console.WriteLine($"{row2["id"].ToString()} - {row2["name"].ToString()}  - {row2["date_birth"].ToString()}");

                    foreach (DataRow row in dt.Rows)
                    {
                        Console.WriteLine($"{row["id"].ToString()} - {row["name"].ToString()}  - {row["date_birth"].ToString()}");
                    }

                }
                db.Close();
            }
        }

        static void SelectFromView()
        {
            using (SqlConnection db = new SqlConnection(conStr))
            {
                db.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM vCity ORDER by name", db))
                {                    
                    DataTable dt = new DataTable();
                    dt.Load(cmd.ExecuteReader());
                    //Console.WriteLine($"ROWS: {dt.Rows.Count} COLUMNS: {dt.Columns.Count}");

                    var row2 = dt.Select("id = 2").FirstOrDefault();
                    if (row2 != null)
                        Console.WriteLine($"{row2["id"].ToString()} - {row2["name"].ToString()}  - {row2["date_birth"].ToString()}");

                    foreach (DataRow row in dt.Rows)
                    {
                        Console.WriteLine($"{row["id"].ToString()} - {row["name"].ToString()}  - {row["date_birth"].ToString()}");
                    }

                }
                db.Close();
            }
        }

        static void SelectFromTableFunction()
        {
            using (SqlConnection db = new SqlConnection(conStr))
            {
                db.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.fCity(2)", db))
                {
                    DataTable dt = new DataTable();
                    dt.Load(cmd.ExecuteReader());
                    foreach (DataRow row in dt.Rows)
                    {
                        Console.WriteLine($"{row["id"].ToString()} - {row["name"].ToString()}  - {row["date_birth"].ToString()}");
                    }

                }
                db.Close();
            }
        }

        static void InsertProc()
        {
            using (SqlConnection db = new SqlConnection(conStr))
            {
                db.Open();
                using (SqlCommand cmd = new SqlCommand("pCity", db))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@name", "Шымкент");
                    cmd.Parameters.AddWithValue("@date_birth", DateTime.Now.AddYears(-100));
                    cmd.ExecuteNonQuery();
                }
                db.Close();
            }
        }
        
        static void MultySet()
        {
            DataSet ds = new DataSet();
            using (SqlConnection db = new SqlConnection("Server=206-P;Database=testDB;Trusted_Connection=True;TrustServerCertificate=true"))
            {
                db.Open();
                using (SqlCommand cmd = new SqlCommand("pMultySet", db))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(ds);
                        for (int i = 0; i < ds.Tables.Count; i++)
                        {
                            foreach (DataRow row in ds.Tables[i].Rows)
                            {
                                Console.WriteLine(row[0].ToString());
                            }
                        }

                    }
                }
                db.Close();
            }
        }
    }
}