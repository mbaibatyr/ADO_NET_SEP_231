﻿using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyEFCore.Model;
using MyEFCore.Models;
using MyEFCore.MyContext;
using System.Data;

namespace MyEFCore
{
    public class Program
    {
        public static IConfigurationRoot config;
        static void Main(string[] args)
        {
            config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();


            //using (SqlConnection db = new SqlConnection(config["db"]))
            //{
            //    db.Open();
            //    SqlTransaction tran = db.BeginTransaction();
            //    try
            //    {
            //        using (SqlCommand cmd = new SqlCommand("pBook;4", db))
            //        {
            //            cmd.Transaction = tran;
            //            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //            SqlDataReader reader = cmd.ExecuteReader();
            //            while (reader.Read())
            //            {
            //                Console.WriteLine($"{reader[0].ToString()} {reader[1].ToString()}");
            //            }
            //            tran.Commit();
            //        }
            //    }
            //    catch (Exception)
            //    {
            //        tran.Rollback();
            //    }

            //    db.Close();
            //}



            //using (SqlConnection db2 = new SqlConnection(config["db"]))
            //{
            //    try
            //    {
            //        db2.Open();
            //        using (SqlCommand cmd = new SqlCommand("pBook;44", db2))
            //        {
            //            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //            SqlDataReader reader = cmd.ExecuteReader();
            //            while (reader.Read())
            //            {
            //                Console.WriteLine($"{reader[0].ToString()} {reader[1].ToString()}");
            //            }
            //        }
            //    }
            //    catch (Exception)
            //    {

            //        throw;
            //    }
            //    finally
            //    {
            //        db2.Close();
            //    }
            //}
            //return;


            using (Context db = new Context())
            {
                //var bookCategory2 = db.BookCategory2.FromSqlRaw("pBook;4");
                //db.Database.ExecuteSqlInterpolated("INSERT INTO ")

                //var transaction = db.Database.BeginTransaction();

                //try
                //{
                //    db.Book.Add(new Models.Book { book_id = 1, book_name = "1234" });
                //    db.SaveChanges();
                //    transaction.Commit();
                //}
                //catch (Exception)
                //{
                //    transaction.Rollback();
                //}



                //var result = db.ReportByCategory.FromSqlRaw("pBook;5");
                //foreach (var item in result)
                //{
                //    Console.WriteLine($"{item.category_name} {item.cnt}");
                //}




                //var bookCategory2 = db.BookCategory2.FromSqlRaw("pBook;4");
                //foreach (var item in bookCategory2)
                //{
                //    Console.WriteLine($"{item.book_name} {item.category_name}");
                //}
                //var books = db.Book.FromSqlInterpolated($"pBook;2 {1}, {3}");
                //foreach (Book item in books)
                //{
                //    Console.WriteLine($"{item.book_id} {item.book_name}");
                //}

                //SqlParameter p_1 = new SqlParameter("@book_id_1", 1);
                //SqlParameter p_2 = new SqlParameter("@book_id_2", 2);
                //var books = db.Book.FromSqlRaw("pBook;2 @book_id_1, @book_id_2", p_1, p_2);
                //foreach (Book item in books)
                //{
                //    Console.WriteLine($"{item.book_id} {item.book_name}");
                //}



                //var books = db.Book.FromSqlRaw("pBook");                
                //foreach (Book item in books)
                //{
                //    Console.WriteLine($"{item.book_id} {item.book_name}");
                //}

                //foreach (var item in db.Parent)
                //{
                //    Console.WriteLine($"{item.id} {item.name}");
                //}


                //var joined = from p in db.Parent
                //             join c in db.Child on p.id equals c.parent_id
                //             select new 
                //             {
                //                 p_name = p.name,
                //                 c_name = c.name
                //             };

                //foreach (var item in joined)
                //{
                //    Console.WriteLine($"{item.p_name} {item.c_name}");
                //}




                //var children = db.Child.ToList();
                //foreach (var ch in children)
                //    Console.WriteLine($"{ch.name} - {ch.Parent?.name}");


                //var p = db.Parent.FirstOrDefault(z => z.id == 1);
                //db.Child.Where(z => z.Parent == p).Load();


                //Console.WriteLine($"parent: {p.name}");
                //foreach (var item in p.Child)
                //    Console.WriteLine($"Child: {item.name}");


                //var result = db.Child
                //            .Include(z => z.Parent)
                //            .ToList();                
                //foreach (var item in result)
                //{
                //    Console.WriteLine($"{item.id}  {item.name} {item.Parent?.name}  ");
                //}


                //var joined = from b in db.Book
                //             join bc in db.BookCategory on b.book_id equals bc.book_id
                //             join c in db.Category on bc.category_id equals c.category_id
                //             select new 
                //             { 
                //                 book_name = b.book_name,
                //                 category_name = c.category_name
                //             };
                //foreach (var item in joined)
                //{
                //    Console.WriteLine($"{item.book_name} {item.category_name}");
                //}

                //var emp = db.Employee.Find(1);

                //var join = (from e in db.Employee
                //           join s in db.Salary on e.id equals s.employee_id
                //           select new
                //           {
                //               emp_id = e.id,
                //               emp_name = e.last_name + " " + e.first_name,
                //               emp_gender = e.gender == "male" ? "мужской" : "женский",
                //               s_sal = s.salary
                //           }).ToList();

                //foreach (var item in join)
                //{
                //    Console.WriteLine($"{item.emp_id} {item.emp_name} {item.emp_gender}  {item.s_sal}");
                //}              




                //foreach (var item in db.Parent)
                //{
                //    Console.WriteLine($"{item.id} - {item.name}");
                //}

                //var result = (from p in db.Parent
                //              join c in db.Child on p.id equals c.parent_id
                //              select new
                //              {
                //                  p_name = p.name,
                //                  c_name = c.name
                //              }).ToList();
                //foreach (var item in result)
                //{
                //    Console.WriteLine($"{item.p_name} - {item.c_name}");
                //}


                // fetch
                //foreach (var item in db.Country)
                //{
                //    Console.WriteLine($"{item.Id} - {item.Name} - {item.Capital}");
                //}


                //add
                //Country country = new Country
                //{
                //    Name = "Россия",
                //    Capital = "Москва"
                //};
                //db.Country.Add(country);
                //db.SaveChanges();

                //List<Country> lst = new List<Country>()
                //{
                //    new Country{Name = "США", Capital = "Вашингтон"},
                //    new Country{Name = "Италия", Capital = "Рим"},
                //};
                //db.Country.AddRange(lst);
                //db.SaveChanges();


                //edit
                //Country? country = db.Country.FirstOrDefault(z => z.Id == 1);
                //if(country != null)
                //{
                //    country.Name = "Казахстан";
                //    country.Capital = "Нур-Султан";
                //    db.SaveChanges();
                //}

                //var country = new Country { Id = 4, Name = "Италия", Capital = "Рим++" };
                //db.Entry<Country>(country).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                //db.SaveChanges();

                //foreach (var item in db.Country)
                //{
                //    Console.WriteLine($"{item.Id} - {item.Name} - {item.Capital}");
                //}

            }

        }
    }
}