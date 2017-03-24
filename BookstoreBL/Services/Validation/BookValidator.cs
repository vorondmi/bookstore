using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;
using Bookstore.Models;

namespace Bookstore.Services.Validation
{
    public class BookValidator : AbstractValidator<Book>
    {
        public BookValidator()
        {
            RuleFor(b => b.bookTitle).Length(1, 20).WithMessage("Must be between 1 and 20 symbols length");
            RuleFor(b => b.release).Must(BeAValidDate).WithMessage("Invalid release date");
        }

        private bool BeAValidDate(DateTime releaseDate)
        {
            return true;
        }
    }
}