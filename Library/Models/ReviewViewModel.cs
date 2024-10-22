using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class ReviewViewModel
    {
        [Key]
        public int ReviewId { get; set; }

        [Required]
        public string Descrptions { get; set; }

        [Required]
        public int BookId { get; set; }

        public string BookName { get; set; }
    }
}

