using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities;

public class Book
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Title { get; set; }
    public int PageCount { get; set; }
    public DateTime PublishDate { get; set; }

    public int GenreId { get; set; }
    public Genre? Genre { get; set; }
    public int AuthorId { get; set; }
    public Author? Author { get; set; }

    public Book(string title, int pageCount, DateTime publishDate, int authorId, int genreId = 1)
    {
        Title = title;
        PageCount = pageCount;
        PublishDate = publishDate;
        AuthorId = authorId;
        GenreId = genreId;
    }
}