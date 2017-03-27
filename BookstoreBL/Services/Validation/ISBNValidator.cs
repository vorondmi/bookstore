using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;
using BookstoreModels;

namespace BookstoreBL.Services.Validation
{
    public class ISBNValidator : AbstractValidator<ISBN>
    {
        public ISBNValidator()
        {
            
        }
    }
}