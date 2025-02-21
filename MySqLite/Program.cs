using Microsoft.Data.Sqlite;
using Dapper;

namespace MySqLite
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //MySqlite.GetData();
            MySqlite.GetData2();
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
                catch { }
                finally
                {
                    db.Close();
                }

            }
        }

        public static void GetData2()
        {
            using (var db = new SqliteConnection(@"Data Source=C:\Users\байбатыровм\Documents\sqlite\MyDB.db;"))
            {
                try
                {
                    var rows = db.Query<Country>("select * from country");
                    {
                        foreach (var row in rows)
                        {
                            Console.WriteLine($"{row.Id} --- {row.Name}");
                        }
                    }
                }
                catch { }
            }
        }
    }

    class Country
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}