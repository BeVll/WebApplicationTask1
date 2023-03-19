using LibraryApp.Data;
using LibraryApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplicationTask1.Pages
{
    public class BookInfoModel : PageModel
    {
        int ID;
        public Book book;
        private readonly IBookRepository _bookRepository;
        public BookInfoModel(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
            
        }


        public void OnGet(int id)
        {
            ID = id;
            book = _bookRepository.GetBookByID(id);
        }

    }
}
