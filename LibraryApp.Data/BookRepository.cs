
using LibraryApp.Models;
using System.Text.Json;

namespace LibraryApp.Data
{
    public class BookRepository : IBookRepository
    {
        List<Book> _books;
        string Path { get; set; }
        public BookRepository()
        {
            Path = "D:\\books.json";
            Load();
        }
        public void AddBook(Book book)
        {
            book.Id = _books.Max(x => x.Id) + 1;
            _books.Add(book);
        }

        public void DeleteBook(int id)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);
            if(book != null)
                _books.Remove(book);
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _books;
        }

        public Book GetBookByID(int id)
        {
            return _books.FirstOrDefault(b => b.Id == id);
        }

        public void UpdateBook(Book book)
        {
            var bookEx = _books.FirstOrDefault(b => b.Id == book.Id);
            if (bookEx != null)
            {
                bookEx.Title = book.Title;
                bookEx.Author = book.Author;
                bookEx.Publisher = book.Publisher;
                bookEx.YearOfPublishing= book.YearOfPublishing;
                bookEx.ImageSrc = book.ImageSrc;
                bookEx.Genre = book.Genre;
                bookEx.Id = book.Id;
                
            }
        }
        public void Save()
        {
            File.Delete(Path);
            string json = JsonSerializer.Serialize(_books);
            File.WriteAllText(Path, json);
        }
        public void Load()
        {
            string str = File.ReadAllText(Path);
            _books = JsonSerializer.Deserialize<List<Book>>(str);
        }
    }
}
internal class Program
{
    static void Main(string[] args)
    { }
}