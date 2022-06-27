using LMS.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Models
{
    public class BookMapping
    {
        public Book Map(BookEntity book)
        {
            var temp = new Book();
            temp.Name = book.Name;
            temp.Publisher = book.Publisher;
            temp.Copies = book.Copies;
            return temp;
        }
        public BookEntity Map(Book book)
        {
            var temp = new BookEntity();
            temp.Name = book.Name;
            temp.Publisher = book.Publisher;
            temp.Copies = book.Copies;
            return temp;
        }
    }
}
