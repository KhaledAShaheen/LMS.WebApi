using LMS.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Models
{
    public class UserMapping
    {
        public UserInfo Map(UserEntity user)
        {
            var temp = new UserInfo();
            temp.id = user.Id;
            temp.Name= user.Name;
            temp.PhoneNum = user.Phone;
            temp.RentBoughtBook = user.BookName;
            temp.FromDate = user.FromDate;
            temp.ToDate=temp.ToDate;
            temp.bookID = temp.bookID;
            return temp;
        }
        public UserEntity Map(UserInfo user)
        {
            var temp = new UserEntity();
            temp.Id = user.id;
            temp.Name = user.Name;
            temp.Phone = user.PhoneNum;
            temp.BookName = user.RentBoughtBook;
            temp.FromDate = user.FromDate;
            temp.ToDate=user.ToDate;
            temp.BookId = user.bookID;
            return temp;
        }
    }
}
}
