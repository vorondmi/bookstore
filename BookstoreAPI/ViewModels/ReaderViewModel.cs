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

        public string genre { get; set; }
    }
}