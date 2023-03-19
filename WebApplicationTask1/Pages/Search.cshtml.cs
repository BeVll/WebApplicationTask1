using LibraryApp.Data;
using LibraryApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplicationTask1.Pages
{
    public class SearchModel : PageModel
    {
        public List<Book> Books { get; set; }

		private readonly IBookSearchService _bookSearch;
        public SearchModel(IBookSearchService bookSearch)
        {
            _bookSearch = bookSearch;
            Books = new List<Book>();   
        }
		public void OnPost(string query)
        {
            
            Books = _bookSearch.SearchBooks(query);
        }
        
    }
}
