using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using MyDapper.Model;
using System.Data;

namespace MyDapper
{
    internal class Program
    {
        public static IConfigurationRoot config;
        static void Main(string[] args)
        {
            config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            //Dap.GetDate();
            //Dap.GetSelect();
            //Dap.GetSelect2();
            Dap.GetBookById("1");
        }
    }

    class Dap
    {
        public static void GetDate()
        {
            using (SqlConnection db = new SqlConnection(Program.config["db"]))
            {
                var result = db.ExecuteScalar<string>("select getdate()");
                Console.WriteLine(result);
            }
        }

        public static void GetSelect()
        {
            using (SqlConnection db = new SqlConnection(Program.config["db"]))
            {
                var result = db.Query<Book>("SELECT book_id, book_name FROM Book");
                foreach (var item in result)
                {
                    Console.WriteLine($"{item.book_name} - {item.book_id}");
                }                
            }
        }

        public static void GetBookById(string id)
        {
            using (SqlConnection db = new SqlConnection(Program.config["db"]))
            {
                DynamicParameters p = new DynamicParameters();
                p.Add("@book_id", id);
                var result = db.Query<Book>("[pBook];6", p, commandType: CommandType.StoredProcedure);
                foreach (var item in result)
                {
                    Console.WriteLine($"{item.book_name} - {item.book_id}");
                }
            }
        }

        public static void GetSelect2()
        {
            using (SqlConnection db = new SqlConnection(Program.config["db"]))
            {
                var result = db.Query<dynamic>("SELECT book_id, book_name FROM Book");
                foreach (var item in result)
                {
                    string book_id = Convert.ToString(item.book_id);
                    Console.WriteLine($"{item.book_name} - {book_id.Trim()}");
                }
            }
        }


        /*
         * [dbo].[pBook];6 2
         */
    }
}