using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Services
{
    public interface IValidationService
    {
        bool EntityIsValid(object entityToValidate); 
    }
}
