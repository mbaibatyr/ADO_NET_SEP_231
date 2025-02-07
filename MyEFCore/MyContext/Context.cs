using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MyEFCore.Model;
using MyEFCore.Models;
using MyEFCore.ViewModel;
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

        //public virtual DbSet<Book> Book { get; set; } = null!;
        //public virtual DbSet<BookCategory> BookCategory { get; set; } = null!;
        //public virtual DbSet<Category> Category { get; set; } = null!;

        public DbSet<Book> Book { get; set; }

        public DbSet<BookCategory2> BookCategory2 { get; set; }
        public DbSet<ReportByCategory> ReportByCategory { get; set; }       


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(Program.config["db"]);
            //optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseSqlServer("Server=.;Database=testDB;Trusted_Connection=True;TrustServerCertificate=true");
            optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
        }       
    }
}

/*
dotnet ef dbcontext scaffold "Server=206-P;Database=testDB;Trusted_Connection=True;TrustServerCertificate=true" Microsoft.EntityFrameworkCore.SqlServer -o Models -t Book -t Category -t BookCategory
Scaffold-DbContext "Server=206-P;Database=testDB;Trusted_Connection=True;TrustServerCertificate=true" Microsoft.EntityFrameworkCore.SqlServer -Tables Book, Category, BookCategory -OutputDir Models 
Scaffold-DbContext "Server=.;Database=testDB;Trusted_Connection=True;TrustServerCertificate=true" Microsoft.EntityFrameworkCore.SqlServer -Tables Book, Category, BookCategory -OutputDir Models 
 

create table Book
(
	book_id int primary key identity,
	book_name nvarchar(100)
)

create table Category
(
	category_id int primary key identity,
	category_name nvarchar(100)
)

create table BookCategory
(
	id int primary key identity,
	book_id int,
	category_id int,
	foreign key (book_id) references Book(book_id),
	foreign key (category_id) references Category(category_id)
)


insert into Category
values (N'Исторический'), (N'Приключение'), (N'Военный')


insert into Book
values (N'Война и мир'), (N'Евгений Онегин'), (N'Белый клык')


insert into BookCategory (book_id, category_id)
values (1, 1), (1, 3), 
		(2, 2), 
		(3, 2), 
		(3, 1) 

SELECT b.book_name,
		c.category_name
FROM Book b JOIN BookCategory bc ON b.book_id = bc.book_id
JOIN Category c ON c.category_id = bc.category_id





 */