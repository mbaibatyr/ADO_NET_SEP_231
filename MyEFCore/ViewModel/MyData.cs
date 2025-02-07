using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEFCore.ViewModel
{
    internal class MyData
    {
    }

    [Keyless]
    public class BookCategory2
    {
        public string category_name { get; set; }
        public string book_name { get; set; }
    }

    [Keyless]
    public class ReportByCategory
    {
        public string category_name { get; set; }
        public int cnt { get; set; }
    }

}
