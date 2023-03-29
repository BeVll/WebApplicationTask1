using LibraryApp.Data;
using LibraryApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static System.Reflection.Metadata.BlobBuilder;

namespace WebApplicationTask1.Pages
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Book Book { get; set; }
        private readonly IBookRepository _bookRepository;
        public EditModel(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
            
        }
        public void OnGet(int id)
        {
            Book = _bookRepository.GetBookByID(id);
        }
        [HttpPost]
        public RedirectResult OnPost()
        {
            if(Book != null)
            {
                _bookRepository.UpdateBook(Book);
                _bookRepository.Save();
               
            }
            return Redirect("/BooksLibrary");
        }
    }
}
