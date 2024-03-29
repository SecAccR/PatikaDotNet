using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Entities;

namespace WebApi.Utilities.DBOperations;

public class DataSeeder
{
    public static void Seed(IServiceProvider serviceProvider)
    {
        using (BookStoreDbContext context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
        {
            if (!context.Books.Any())
            {
                context.Books.AddRange(new List<Book>()
                    {
                        new Book("Lean Startup", 200, new DateTime(2001, 6, 12), 1, 3),
                        new Book("Herland", 250, new DateTime(2010, 5, 23), 2, 2),
                        new Book("Dune", 540, new DateTime(2002, 12, 21), 3, 2)
                    });
            }

            if (!context.Genres.Any())
            {
                context.Genres.AddRange(
                    [
                        new Genre("None"),
                        new Genre("Science Fiction"),
                        new Genre("Personal Growth"),
                        new Genre("Novel")
                    ]);
            }

            if (!context.Authors.Any())
            {
                context.Authors.AddRange(
                    [
                        new Author("Eric", "Ries"),
                        new Author("Charlotte", "Gilman"),
                        new Author("Frank", "Herbert"),
                        new Author("John Ronald Reuel", "Tolkien")
                    ]);
            }

            context.SaveChanges();
        }
    }
}