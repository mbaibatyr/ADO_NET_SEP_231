using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyEFCore.Models
{
    public partial class Category
    {
        public Category()
        {
            BookCategory = new HashSet<BookCategory>();
        }
        [Key]
        public int category_id { get; set; }
        public string? category_name { get; set; }

        public virtual ICollection<BookCategory> BookCategory { get; set; }
    }
}
