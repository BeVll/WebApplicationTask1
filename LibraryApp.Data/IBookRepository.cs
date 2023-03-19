using LibraryApp.Models;

namespace LibraryApp.Data
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetAllBooks();
        void DeleteBook(int id);
        Book GetBookByID(int id);
        void AddBook(Book book);
        void UpdateBook(Book book);
        void Save();
		void Load();
	}
}
