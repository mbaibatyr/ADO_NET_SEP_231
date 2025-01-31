using System;
using System.Collections.Generic;

namespace MyEFCore.Models
{
    public partial class Book
    {
        public Book()
        {
            BookCategories = new HashSet<BookCategory>();
        }

        public int BookId { get; set; }
        public string? BookName { get; set; }

        public virtual ICollection<BookCategory> BookCategories { get; set; }
    }
}
