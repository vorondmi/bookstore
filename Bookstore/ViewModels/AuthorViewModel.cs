using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bookstore.Models;

namespace Bookstore.ViewModels
{
    public class AuthorViewModel
    {
        public Guid id { get; set; }

        public string authorName { get; set; }

        public bool alive { get; set; }

        public List<Book> books { get; set; }

        public List<Reader> readers { get; set; }
    }
}