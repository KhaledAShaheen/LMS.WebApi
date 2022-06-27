
using System.Data.SqlClient;
using LMS.Classes;
using LMS.DAL.EF;
using LMS.Interface;
using LMS.Models;
using Microsoft.Extensions.Logging;

namespace LMS.BL.Managers
{
    public class UserSqlManager : IUserManager
    {
        private readonly EntityFramworkContext _context;
        private readonly ILogger<UserSqlManager> _logger;
        private UserMapping _userMapping;

        public UserSqlManager(EntityFramworkContext context, ILogger<UserSqlManager> logger)
        {
            _context = context;
            _userMapping = new UserMapping();
            _logger = logger;   
        }
        public List<UserInfo> GetUsersList()
        {
            try
            {
                List<UserInfo> _users = new List<UserInfo>();
                var choosenBook = _context.UserEntities.ToList();
                foreach (var i in choosenBook)
                {
                    _users.Add(_userMapping.Map(i));
                }
                return _users;
            }
            catch(Exception ex)
            {
                _logger.LogInformation(ex.ToString());
                return null;
            }
        }
        public void RemoveUserById(int id)
        {
            try
            {
                var userToDelete = _context.UserEntities.FirstOrDefault(x => x.Id == id);
                _context.Remove(userToDelete);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.ToString());
            }
        }
        public UserInfo CreateUser(UserInfo user)
        {
            try
            {
                var userToCreate = new UserEntity() { Name = user.Name, Phone = user.PhoneNum, BookName = user.RentBoughtBook, FromDate = user.FromDate, ToDate = user.ToDate, BookId = user.bookID };
                _context.UserEntities.Add(userToCreate);
                _context.SaveChanges();
                return _userMapping.Map(userToCreate);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.ToString());
                return null;
            }
        }
        public bool IsUserAval(int id)
        {
            try
            {
                var user = _context.UserEntities.FirstOrDefault(x => x.Id == id);
                if (user != null) return true;
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.ToString());
                return false;
            }
        }
        public UserInfo UpdateUser(UserInfo user)
        {
            try
            {
                if (IsUserAval(user.id))
                {
                    var userToUpdate = _context.UserEntities.FirstOrDefault(x => x.Id == user.id);
                    if (!string.IsNullOrEmpty(user.Name)) userToUpdate.Name = user.Name;
                    if (!string.IsNullOrEmpty(user.PhoneNum)) userToUpdate.Phone = user.PhoneNum;
                    if (!string.IsNullOrEmpty(user.RentBoughtBook)) userToUpdate.BookName = user.RentBoughtBook;
                    if (!string.IsNullOrEmpty(user.FromDate)) userToUpdate.FromDate = user.FromDate;
                    if (!string.IsNullOrEmpty(user.Name)) userToUpdate.ToDate = user.ToDate;
                    _context.SaveChanges();
                    return _userMapping.Map(userToUpdate);
                }
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.ToString());
                return null;
            }

        }
    }
}
   
