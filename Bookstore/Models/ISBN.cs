using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Bookstore.Models
{
    public class ISBN
    {
        [Key]
        public Guid id { get; set; }

        [Required]
        [Range(0, 20)]
        public int isbn { get; set; }

        public Country country { get; set; }

        public virtual Book book { get; set; }
    }

    public enum Country
    {
        LT,
        LV,
        EST
    }
}