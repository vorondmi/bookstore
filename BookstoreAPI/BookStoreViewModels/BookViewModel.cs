using System;
using System.Collections.Generic;

namespace BookstoreAPI.BookStoreViewModels
{
    public class BookViewModel
    {
        public Guid id { get; set; }

        public string bookTitle { get; set; }

        public DateTime release { get; set; }

        public IEnumerable<ReaderViewModel> readers { get; set; }

        //public IEnumerable<IDStringPair> authors { get; set; }

        //public IEnumerable<IDStringPair> isbns { get; set; }
    }
}