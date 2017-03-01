using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bookstore.Models;

namespace Bookstore.ViewModels
{
    public class ReaderViewModel
    {
        public Guid id { get; set; }

        public string name { get; set; }

        public Genre genre { get; set; }

        public IEnumerable<Book> books { get; set; }

        public IEnumerable<Author> authors { get; set; }
    }

    public enum Genre
    {
        Drama,
        Detective,
        SciFi
    }
}