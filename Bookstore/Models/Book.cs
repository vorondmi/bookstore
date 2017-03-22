using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bookstore.Models
{
    public class Book
    {
        [Key]
      //  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }

        [Required]
        public string bookTitle { get; set; }

        public DateTime release { get; set; }

        public virtual ISBN isbn { get; set; }

        public virtual List<Reader> readers { get; set; }

        public virtual Author author { get; set; }
    }
}