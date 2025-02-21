using Microsoft.Data.Sqlite;

namespace MySqLite
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MySqlite.GetData();
        }
    }

    class MySqlite
    {
        public static void GetData()
        {
            using (var db = new SqliteConnection(@"Data Source=C:\Users\байбатыровм\Documents\sqlite\MyDB.db;"))
            {
                try
                {
                    db.Open();
                    using (var cmd = new SqliteCommand("select * from country", db))
                    {
                        var dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            Console.WriteLine($"{dr[0]} - {dr[1]}");
                        }
                    }
                }
                catch {}
                finally
                {
                    db.Close();
                }
                
            }
        }
    }
}