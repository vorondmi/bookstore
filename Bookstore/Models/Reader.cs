using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Bookstore.Models
{
    public class Reader
    {
        [Key]
        public Guid id { get; set; }

        [Required]
        public string name { get; set; }

        public Genre genre { get; set; }

        public virtual List<Book> books { get; set; }

        public virtual List<Author> authors { get; set; }
    }

    public enum Genre
    {
        Drama,
        Detective,
        SciFi
    }
}