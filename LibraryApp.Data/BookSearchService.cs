using LibraryApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Data
{
    public class BookSearchService : IBookSearchService
    {
        private readonly IBookRepository _bookRepository;

        public BookSearchService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public List<Book> SearchBooks(string query)
        {
            string[] words = query.ToLower().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            List<Book> books = _bookRepository.GetAllBooks().Where(b => words.Any(word => b.Title.ToLower().Contains(word) || b.Author.ToLower().Contains(word) || b.Genre.ToLower().Contains(word) || b.Publisher.ToLower().Contains(word) || b.YearOfPublishing.ToString().ToLower().Contains(word))).ToList();
            
            return books;
        }


    }
}
