using AutoMapper;
using WebApi.Entities;
using static WebApi.Utilities.Operations.BookOperations.CreateBook.CreateBookCommand;
using static WebApi.Utilities.Operations.BookOperations.GetBooks.GetBookCommand;
using static WebApi.Utilities.Operations.BookOperations.GetBooks.GetBooksQuery;
using static WebApi.Utilities.Operations.BookOperations.UpdateBook.UpdateBookCommand;

namespace WebApi.Utilities.Profiles;

public class BookMappingProfile : Profile
{
    public BookMappingProfile()
    {
        CreateMap<CreateBookModel, Book>();
        CreateMap<Book, BookViewModel>()
            .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name))
            .ForMember(dest => dest.Author, opt => opt.MapFrom(src => $"{src.Author.Name} {src.Author.Surname}"))
            .ForMember(dest => dest.PublishDate, opt => opt.MapFrom(src => src.PublishDate.Date.ToString("dd.MM.yyyy")));
        CreateMap<Book, BooksViewModel>()
            .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name))
            .ForMember(dest => dest.Author, opt => opt.MapFrom(src => $"{src.Author.Name} {src.Author.Surname}"))
            .ForMember(dest => dest.PublishDate, opt => opt.MapFrom(src => src.PublishDate.Date.ToString("dd.MM.yyyy")));
        CreateMap<UpdateBookModel, Book>();
    }
}