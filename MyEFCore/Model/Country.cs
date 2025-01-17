using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEFCore.Model
{
    //public class Country
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //    public string Capital { get; set; }
    //    public List<City> City { get; set; }
    //}

    //public class City
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //    public Country Country { get; set; }
    //    public int CountryId { get; set; }
    //}

    //[Table("Students")]
    //public class Student
    //{
    //    public int Id { get; set; }

    //    public string Name { get; set; }
    //    [NotMapped]
    //    public string Field2 { get; set; }
    //}

    //public class Person
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }        
    //    public Document Document { get; set; }

    //}

    //public class Document
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //    public Person Person { get; set; }        
    //    public int PersonId { get; set; }
    //}

    //[Table("Country2")]
    //public class Country2
    //{
    //    [Key]
    //    public int Id { get; set; }
    //    [MaxLength(200), Required]
    //    public string Name { get; set; }
    //    public Capital Capital { get; set; }
    //}

    //[Table("Capital")]
    //public class Capital
    //{
    //    [Key]
    //    public int Id { get; set; }
    //    [MaxLength(200)]
    //    public string Name { get; set; }
    //    public int Country2Id { get; set; }
    //    public Country2 Country2 { get; set; }
    //}

    [Table("Parent")]
    public class Parent
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<Child> Child { get; set; }
    }

    [Table("Child")]
    public class Child
    {
        public int id { get; set; }
        public string name { get; set; }
        public int parent_id { get; set; }
        public Parent Parent { get; set; }
    }
}

