using LibraryApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Data
{
    public interface  IBookSearchService
    {
        List<Book> SearchBooks(string query);

	}
}
