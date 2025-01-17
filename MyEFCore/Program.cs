using Microsoft.Extensions.Configuration;
using MyEFCore.Model;
using MyEFCore.MyContext;

namespace MyEFCore
{
    public class Program
    {
        public static IConfigurationRoot config;
        static void Main(string[] args)
        {
            config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            using (Context db = new Context())
            {
                foreach (var item in db.Parent)
                {
                    Console.WriteLine($"{item.id} - {item.name}");
                }

                var result = (from p in db.Parent
                              join c in db.Child on p.id equals c.parent_id
                              select new
                              {
                                  p_name = p.name,
                                  c_name = c.name
                              }).ToList();
                foreach (var item in result)
                {
                    Console.WriteLine($"{item.p_name} - {item.c_name}");
                }


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