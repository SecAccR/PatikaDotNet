using System;

namespace Webapi.Models;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int PageCount { get; set; }
    public DateTime PublishDate { get; set; }
    public int GenreId { get; set; }

    public Book(int id, string title, int pageCount, DateTime publishDate, int genreId)
    {
        Id = id;
        Title = title;
        PageCount = pageCount;
        PublishDate = publishDate;
        GenreId = genreId;
    }
}