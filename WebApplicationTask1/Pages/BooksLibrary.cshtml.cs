using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LibraryApp.Data;
using LibraryApp.Models;

namespace WebApplicationTask1.Pages
{
    public class BooksLibraryModel : PageModel
    {
        public IEnumerable<Book> Books;
        private readonly IBookRepository _bookRepository;
        public BooksLibraryModel(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public void OnGet()
        {
            Books = _bookRepository.GetAllBooks();
        }
        public void OnPost(string id)
        {
            _bookRepository.DeleteBook(Convert.ToInt32(id));
            _bookRepository.Save();
            _bookRepository.Load();
			Books = _bookRepository.GetAllBooks();
		}
    }
}
