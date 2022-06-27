using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace LMS.Classes
{
    public class UserInfo
    {
        public int id { get; set; } 
        public int bookID { get; set; } 
        public string Name { get; set; }
        public string PhoneNum { get; set; }
        public string RentBoughtBook { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }

        public UserInfo()
        {

        }
        public UserInfo(int Id, string name, string phone, string book, string fromDate, string toDate, int bookID)
        {
            id = Id;
            Name = name;
            PhoneNum = phone;
            RentBoughtBook = book;
            FromDate = fromDate;
            ToDate = toDate;
            this.bookID = bookID;

        }

    }
}
