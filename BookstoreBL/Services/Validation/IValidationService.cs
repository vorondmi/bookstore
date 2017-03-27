using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreBL.Services.Validation
{
    public interface IValidationService
    {
        bool EntityIsValid(object entityToValidate); 
    }
}
