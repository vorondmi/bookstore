using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bookstore.Models;

namespace Bookstore.ViewModels
{
    public class ISBNViewModel
    {
        public Guid id { get; set; }

        public int isbn { get; set; }

        public Country country { get; set; }

        public Book book { get; set; }
    }

    public enum Country
    {
        LT,
        LV,
        EST
    }
}