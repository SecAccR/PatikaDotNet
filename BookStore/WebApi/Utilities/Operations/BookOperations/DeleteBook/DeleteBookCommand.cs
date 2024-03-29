using System;
using System.Linq;
using WebApi.Entities;
using WebApi.Utilities.DBOperations;

namespace WebApi.Utilities.Operations.BookOperations.DeleteBook;

public class DeleteBookCommand
{
    private readonly IBookStoreDbContext _context;
    public int Id { get; }

    public DeleteBookCommand(IBookStoreDbContext context, int id)
    {
        _context = context;
        Id = id;
    }

    public void Handle()
    {
        Book? book = _context.Books.SingleOrDefault(x => x.Id == Id);

        if (book == null) throw new InvalidOperationException("Book does not exist!");

        _context.Books.Remove(book);
        _context.SaveChanges();
    }
}