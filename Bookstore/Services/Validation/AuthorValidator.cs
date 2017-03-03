using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;
using Bookstore.Models;

namespace Bookstore.Services.Validation
{
    public class AuthorValidator : AbstractValidator<Author>
    {
        public AuthorValidator()
        {
            RuleFor(a => a.authorName).NotEmpty().Length(1, 20).WithMessage("Author name must be between 1 and 20 length");
        }
    }
}