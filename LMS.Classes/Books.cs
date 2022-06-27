using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Classes
{
    public class Book
    {

        public string Name { get; set; }    
        public string Publisher { get; set; }
        public int Copies { get; set; }
        
        public int Id { get; set; }

        public Book()
        {

        }
        public Book(int id, string name, string publisher, int copy)
        {
            Id = id;
            Name = name;
            Publisher = publisher;
            Copies = copy;
        }

    }
}
