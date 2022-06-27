
using LMS.Classes;

namespace LMS.Interface
{
    public interface IBookManager
    {
        public Book GetBookByName(string bookName);  
       
        public List<Book> GetBooksList();
       
        public Book CreateBook(Book book);
        
        public void DeleteBook(int id);
        public Book UpdateBook(Book book);
        public void IncreaseCopies(int bookId);


        public void DecreaseCopies(int bookId);

        public bool IsBookAval(int bookId);
       
    }
}