using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Models
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string BookName { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }

        [ForeignKey("Book")]
        public int BookId { get; set; }
        public virtual BookEntity book { get; set; }

    }
}
