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
            Dap.GetSelect();
            //Dap.GetSelect2();
            //Dap.GetBookById("1");
            //Dap.GetBookById2("2");
            //Dap.BookAdd(new Book { book_id = "1004", book_name = "Сказки - 3" });
            //Dap.MultySelect();
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
                var result = db.Query<Book>("SELECT book_id, book_name, getdate() dt FROM Book");
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

        public static void GetBookById2(string id)
        {
            using (SqlConnection db = new SqlConnection(Program.config["db"]))
            {                
                var result = db.Query<Book>("[pBook];6", new { book_id=id }, commandType: CommandType.StoredProcedure);
                foreach (var item in result)
                {
                    Console.WriteLine($"{item.book_name} - {item.book_id}");
                }
            }
        }

        public static void BookAdd(Book model)
        {
            using (SqlConnection db = new SqlConnection(Program.config["db"]))
            {
                DynamicParameters p = new DynamicParameters(model);
                db.Execute("[pBook];7", p, commandType: CommandType.StoredProcedure);
                //db.Execute("[pBook];7", new { book_id  = model.book_id, book_name  = model.book_name}, commandType: CommandType.StoredProcedure);
            }
        }

        public static void MultySelect()
        {
            using (SqlConnection db = new SqlConnection(Program.config["db"]))
            {
                using (var read = db.QueryMultiple("[pBook];8", commandType: CommandType.StoredProcedure))
                {
                    var first = read.Read<dynamic>();
                    var second = read.Read<dynamic>();
                    foreach (var item in first)
                    {
                        Console.WriteLine($"{item.book_name} - {item.book_id}");
                    }


                    foreach (var item in second)
                    {
                        Console.WriteLine($"{item.category_name} - {item.category_id}");
                    }

                }

            }
        }
    }
}