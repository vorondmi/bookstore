using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Bookstore.Services;

namespace Bookstore.BL
{
    public class ValidationService : IValidationService
    {
        public bool EntityIsValid(object entityToValidate)
        {
            return Validator.TryValidateObject(
                entityToValidate, 
                new ValidationContext(entityToValidate, null, null), 
                new List<ValidationResult>()
                );
        }
    }
}