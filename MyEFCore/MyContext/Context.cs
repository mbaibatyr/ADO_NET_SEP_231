using Microsoft.EntityFrameworkCore;
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
        public DbSet<Country> Country { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {            
            optionsBuilder.UseSqlServer(Program.config["db"]);
            //optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\Temp\\db_test.mdf;Integrated Security=True;TrustServerCertificate=true;");
            //optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
        }
    }
}
