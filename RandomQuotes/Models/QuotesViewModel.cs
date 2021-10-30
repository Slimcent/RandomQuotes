using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RandomQuotes.Models
{
    public class QuotesViewModel : IEntity
    {
        public int Id { get; set; }

        [Required, MinLength(4), MaxLength(200)]
        public string Quote { get; set; }

        [Required, MinLength(4), MaxLength(50)]
        public string Author { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}
