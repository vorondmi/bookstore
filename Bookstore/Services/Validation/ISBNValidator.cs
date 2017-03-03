using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;
using Bookstore.Models;

namespace Bookstore.Services.Validation
{
    public class ISBNValidator : AbstractValidator<ISBN>
    {
        public ISBNValidator()
        {
            
        }
    }
}