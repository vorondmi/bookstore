using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bookstore.Models;

namespace Bookstore.ViewModels
{
    public class ComplexAuthorViewModel
    {
        public string authorName { get; set; }

        public bool alive { get; set; }

        public List<BookViewModel> books { get; set; }
    }
}