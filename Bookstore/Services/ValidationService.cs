using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Bookstore.BL
{
    public class ValidationService
    {
        public static bool EntityIsValid(object entityToValidate)
        {
            return Validator.TryValidateObject(
                entityToValidate, 
                new ValidationContext(entityToValidate, null, null), 
                new List<ValidationResult>()
                );
        }
    }
}