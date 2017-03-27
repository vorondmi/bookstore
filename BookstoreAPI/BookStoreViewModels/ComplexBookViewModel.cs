using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookstoreAPI.BookStoreViewModels
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
        public List<ReaderViewModel> readers { get; set; }
    }
}