using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BookstoreModels
{
    public class Author
    {
        [Key]
        public Guid id { get; set; }

        [Required]
        public string authorName { get; set; }

        public bool alive { get; set; }

        public virtual List<Book> books { get; set; }

        public virtual List<Reader> readers { get; set; }
    }
}