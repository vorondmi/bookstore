using System;
using System.ComponentModel.DataAnnotations;

namespace BookstoreModels
{
    public class ISBN
    {
        [Key]
        public Guid id { get; set; }

        [Required]
        [Range(0, 1000)]
        public int isbn { get; set; }

        public string country { get; set; }

        public virtual Book book { get; set; }
    }
}