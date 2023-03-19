using LibraryApp.Data;
using LibraryApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static System.Reflection.Metadata.BlobBuilder;

namespace WebApplicationTask1.Pages
{
    public class AddModel : PageModel
    {
        [BindProperty]
        public Book Book { get; set; }
        private readonly IBookRepository _bookRepository;
        public AddModel(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
            Book = new Book();
        }
        public void OnGet()
        {
          
        }
        [HttpPost]
        public ActionResult OnPost()
        {
            if (Book != null)
            {
                List<Book> books = _bookRepository.GetAllBooks().ToList();
                int maxId = books.Max(x => x.Id);
                Book.Id = maxId + 1;
                _bookRepository.AddBook(Book);
                _bookRepository.Save();
                Book = new Book();
            }
            return null;
        }
    }
}
