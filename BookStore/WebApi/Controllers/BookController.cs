using System;
using Microsoft.AspNetCore.Mvc;
using WebApi.BookOperations.CreateBook;
using WebApi.BookOperations.DeleteBook;
using WebApi.BookOperations.GetBooks;
using WebApi.BookOperations.UpdateBook;
using WebApi.DBOperations;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]s")]
public class BookController : ControllerBase
{
    private readonly BookStoreDbContext _context;

    public BookController(BookStoreDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetBooks()
    {
        GetBooksQuery query = new(_context);

        return Ok(query.Handle());
    }

    [HttpGet("{id:int}")]
    public IActionResult GetBookById(int id)
    {
        GetBookCommand command = new(_context) { Id = id };

        try
        {
            return Ok(command.Handle());
        }
        catch (Exception exp)
        {
            return BadRequest(exp.Message);
        }
    }

    // [HttpGet]
    // public Book? GetBookByIdQuery([FromQuery] string id)
    // {
    //     return _context.Books.SingleOrDefault(x => x.Id == Convert.ToInt32(id));
    // }

    [HttpPost]
    public IActionResult AddBook([FromBody] CreateBookCommand.CreateBookModel newBook)
    {
        CreateBookCommand command = new(_context) { BookModel = newBook };

        try
        {
            command.Handle();
        }
        catch (Exception exp)
        {
            return BadRequest(exp.Message);
        }

        return Ok();
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdateBook(int id, [FromBody] UpdateBookCommand.UpdateBookModel updatedBook)
    {
        UpdateBookCommand command = new(_context) { Id = id, BookModel = updatedBook };

        try
        {
            command.Handle();
        }
        catch (Exception exp)
        {
            return BadRequest(exp.Message);
        }

        return Ok();
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteBook(int id)
    {
        DeleteBookCommand command = new(_context) { Id = id };

        try
        {
            command.Handle();
        }
        catch (Exception exp)
        {
            return BadRequest(exp.Message);
        }

        return Ok();
    }
}