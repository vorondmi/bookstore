using Bookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Bookstore.ViewModels
{
    public class BookViewModel
    {
        public Guid id { get; set; }

        public string bookTitle { get; set; }

        public DateTime release { get; set; }

        public IEnumerable<IDStringPair> authors { get; set;}

        public IEnumerable<IDStringPair> isbns { get; set; }

        public IEnumerable<IDStringPair> readers { get; set; }
    }
}