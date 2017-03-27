using FluentValidation;
using BookstoreModels;

namespace BookstoreBL.Services.Validation
{
    public class AuthorValidator : AbstractValidator<Author>
    {
        public AuthorValidator()
        {
            RuleFor(a => a.authorName).NotEmpty().Length(1, 20).WithMessage("Author name must be between 1 and 20 length");
        }
    }
}