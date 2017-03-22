using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bookstore.ViewModels
{
    public class BookDetailViewModel
    {
        public Guid id { get; set; }

        public string bookTitle { get; set; }

        public DateTime release { get; set; }

        public IEnumerable<ReaderViewModel> readers { get; set; }
    }
}