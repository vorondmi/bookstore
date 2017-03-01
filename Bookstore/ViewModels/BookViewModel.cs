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

        public Guid authorID { get; set; }

        public IEnumerable<Author> authors { get; set; }

        public Guid isbnID { get; set; }

        public IEnumerable<ISBN> isbns { get; set; }

        public List<CheckBoxModel> readerCheckBoxes { get; set; }
    }
}