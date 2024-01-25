using FluentValidation;

namespace WebApi.Operations.BookOperations.UpdateBook;

class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
{
    public UpdateBookCommandValidator()
    {
        RuleFor(x => x.Id).NotNull().NotEmpty().GreaterThan(0);
        RuleFor(x => x.BookModel.Title).NotEmpty().MinimumLength(4);
        RuleFor(x => x.BookModel.PageCount).NotNull().GreaterThan(0);
        RuleFor(x => x.BookModel.PublishDate).NotNull().LessThan(System.DateTime.Today);
        RuleFor(x => x.BookModel.GenreId).NotNull().GreaterThan(0);
    }
}