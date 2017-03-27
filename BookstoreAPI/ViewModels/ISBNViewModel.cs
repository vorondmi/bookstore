using System;

namespace Bookstore.ViewModels
{
    public class ISBNViewModel
    {
        public Guid id { get; set; }

        public int isbn { get; set; }

        public string country { get; set; }
    }
}