using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Webapi.Models;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]s")]
public class BookController : ControllerBase
{
    static List<Book> BookList = new List<Book>()
    {
        new Book(1, "Lean Startup", 200, new DateTime(2001, 6, 12), 1),
        new Book(2, "Herland", 250, new DateTime(2010, 5, 23), 2),
        new Book(3, "Dune", 540, new DateTime(2002, 12, 21), 2)
    };

    [HttpGet]
    public List<Book> GetBooks()
    {
        return BookList.OrderBy(x => x.Id).ToList();
    }

    [HttpGet("{id:int}")]
    public Book? GetBookById(int id)
    {
        return BookList.SingleOrDefault(x => x.Id == id);
    }

    // [HttpGet]
    // public Book? GetBookByIdQuery([FromQuery] string id)
    // {
    //     return BookList.SingleOrDefault(x => x.Id == Convert.ToInt32(id));
    // }
}