using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookstoreAPI.BookStoreViewModels
{
    public class NewBookViewModel
    {
        public Guid id { get; set; }

        public string bookTitle { get; set; }

        public DateTime release { get; set; }

        public Guid authorID { get; set; }

        public Guid isbnID { get; set; }

        public Guid[] readerIDs { get; set; }
    }
}