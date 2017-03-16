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

        public string country { get; set; }
    }
}