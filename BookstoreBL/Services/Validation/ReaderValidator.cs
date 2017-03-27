using FluentValidation;
using BookstoreModels;

namespace BookstoreBL.Services.Validation
{
    public class ReaderValidator : AbstractValidator<Reader>
    {
        public ReaderValidator()
        {
            RuleFor(r => r.name).Length(1, 15).WithMessage("Reader name must be between 1 and 15 symbols length");
        }
    }
}