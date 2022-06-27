
using LMS.Classes;
using LMS.DAL.EF;
using LMS.Interface;
using LMS.Models;
using Microsoft.Extensions.Logging;

namespace LMS.BL.Managers
{
    public class BookSqlManager : IBookManager
    {

        private readonly EntityFramworkContext _context;
        private readonly ILogger<BookSqlManager> _logger;
        private BookMapping _BookMapping;

        public BookSqlManager(EntityFramworkContext _context, ILogger<BookSqlManager> logger)
        {
            this._context = _context;
            _logger = logger;
            _BookMapping = new BookMapping();
        }
    
        public Book GetBookByName(string bookName)
        {
            try
            {
                var choosenBook = _context.BookEntities.FirstOrDefault(x => x.Name == bookName);
                return _BookMapping.Map(choosenBook);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.ToString());
                return null;
            }
        }
       
        public List<Book> GetBooksList()
        {
            var choosenBook = _context.BookEntities.ToList();
            var books = new List<Book>();
            foreach(var i in choosenBook)
            {
                books.Add(new Book(i.Id,i.Name,i.Publisher,i.Copies));
            }
            return books;
        }

        public Book CreateBook(Book book)
        {
            try
            {
                var newBook = new BookEntity() { Name = book.Name, Publisher = book.Publisher, Copies = book.Copies };
                _context.BookEntities.Add(newBook);
                _context.SaveChanges();
                return _BookMapping.Map(newBook);
            }
            catch(Exception ex)
            {
                _logger.LogInformation(ex.ToString());
                return null;
            }
        }
        public void DeleteBook(int id)
        {
            try
            {
                var bookToDelete = _context.BookEntities.FirstOrDefault(x => x.Id == id);
                _context.Remove(bookToDelete);
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                _logger.LogInformation(ex.ToString());
            }
        }
        public Book UpdateBook(Book book)
        {
            try
            {
                if (IsBookAval(book.Id))
                {

                    var bookToUpdate = _context.BookEntities.FirstOrDefault(x => x.Id == book.Id);
                    if (!string.IsNullOrEmpty(book.Name)) bookToUpdate.Name = book.Name;
                    if (!string.IsNullOrEmpty(book.Publisher)) bookToUpdate.Publisher = book.Publisher;
                    if (book.Copies > 0) bookToUpdate.Copies = book.Copies;
                    _context.SaveChanges();
                    return _BookMapping.Map(bookToUpdate);
                }
                return null;
            }
            catch(Exception ex)
            {
                _logger.LogInformation(ex.ToString());
                return null;
            }
        }
        public bool IsBookAval(int bookId)
        {
            try
            {
                var choosenBook = _context.BookEntities.FirstOrDefault(x => x.Id == bookId);
                int copies = choosenBook.Copies;
                if (copies > 0 || choosenBook != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                _logger.LogInformation(ex.ToString());
                return false;
            }
        }
        
        public void IncreaseCopies(int bookId)
        {
            try
            {
                var choosenBook = _context.BookEntities.FirstOrDefault(x => x.Id == bookId);
                choosenBook.Copies += 1;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.ToString());
            }
        }
        
        public void DecreaseCopies(int bookId)
        {
            try
            {
                var choosenBook = _context.BookEntities.FirstOrDefault(x => x.Id == bookId);
                choosenBook.Copies -= 1;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.ToString());
            }
        }
    }
}