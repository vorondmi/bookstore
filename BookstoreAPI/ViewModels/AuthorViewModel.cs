using System;

namespace Bookstore.ViewModels
{
    public class AuthorViewModel
    {
        public Guid id { get; set; }

        public string authorName { get; set; }

        public bool alive { get; set; }
    }
}