using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bookstore.Services
{
    public class BLResponse<T>
    {
        bool hasErrors { get; set; }
        List<string> errors { get; set; }
        T Result { get; set; }
    }
}