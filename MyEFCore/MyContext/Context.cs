using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MyEFCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEFCore.MyContext
{
    public class Context : DbContext
    {
        //public DbSet<Country> Country { get; set; }
        //public DbSet<City> City { get; set; }
        //public DbSet<Student> Student { get; set; }

        //public DbSet<Person> Person{ get; set; }
        //public DbSet<Document> Document { get; set; }

        //public DbSet<Country2> Country2 { get; set; }
        //public DbSet<Capital> Capital { get; set; }

        //public DbSet<Parent> Parent { get; set; }
        //public DbSet<Child> Child { get; set; }

        //public DbSet<Employee> Employee { get; set; }
        //public DbSet<Salary> Salary { get; set; }


        //public DbSet<Order> Order { get; set; }
        //public DbSet<Product> Product { get; set; }
        //public DbSet<OrderDetails> OrderDetails { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {            
            //optionsBuilder.UseSqlServer(Program.config["db"]);
            optionsBuilder.UseSqlServer("Server=206-P;Database=testDB;Trusted_Connection=True;TrustServerCertificate=true");
            optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
        }       
    }
}

/*
dotnet ef dbcontext scaffold "Server=206-P;Database=testDB;Trusted_Connection=True;TrustServerCertificate=true" Microsoft.EntityFrameworkCore.SqlServer -o Models -t Book -t Category -t BookCategory
 
 */