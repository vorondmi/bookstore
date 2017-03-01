using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Bookstore.Models;

namespace Bookstore.ViewModels
{
    public class ComplexBookViewModel
    {
        public Guid id { get; set; }

        [Display(Name = "ISBN")]
        public int isbn { get; set; }

        [Display(Name = "Title")]
        public string bookTitle { get; set; }

        [Display(Name = "Release date")]
        public DateTime release { get; set; }

        [Display(Name = "Author")]
        public string authorName { get; set; }

        [Display(Name = "Readers")]
        public List<Reader> readers { get; set; }
    }
}