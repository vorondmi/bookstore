using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bookstore.Models
{
    public class Reader
    {
        [Key]
        public Guid id { get; set; }

        [Required]
        public string name { get; set; }

        public string genre { get; set; }

        public virtual List<Book> books { get; set; }

        public virtual List<Author> authors { get; set; }
    }
}