using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LMS.Classes;

namespace LMS.Interface
{
    public interface IUserManager
    {
        public List<UserInfo> GetUsersList();
        public void RemoveUserById(int id);
        public UserInfo CreateUser(UserInfo user);
        public UserInfo UpdateUser(UserInfo user);
        public bool IsUserAval(int id);
    }
}
