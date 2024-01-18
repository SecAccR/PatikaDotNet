using System.Collections.Generic;
using System.Linq;
using Webapi.Entities;
using WebApi.DBOperations;
using WebApi.Enums;

namespace WebApi.BookOperations.GetBooks;

class GetBooksQuery
{
    private readonly BookStoreDbContext _context;

    public GetBooksQuery(BookStoreDbContext context)
    {
        _context = context;
    }

    public List<BooksViewModel> Handle()
    {
        List<Book> bookList = _context.Books.OrderBy(x => x.Title).ToList();
        List<BooksViewModel> booksVMList = new();

        foreach (Book book in bookList)
        {
            booksVMList.Add(new BooksViewModel()
            {
                Title = book.Title,
                PageCount = book.PageCount,
                PublishDate = book.PublishDate.Date.ToString("dd.MM.yyyy"),
                Genre = ((GenreEnum)book.GenreId).ToString()
                // Genre = book.GenreId switch
                // {
                //     1 => "Personal Growth",
                //     2 => "Science Fiction"
                // }
            });
        }

        return booksVMList;
    }

    public class BooksViewModel()
    {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
        public string Genre { get; set; }
    }
}