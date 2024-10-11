using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Models
{
    public class Reservation
    {
        [Key]
        public int ReservationID { get; set; }
        public int BookID { get; set; } // Foreign key for the Book
        public string UserID { get; set; } // Foreign key for the User
        public DateTime ReservationDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime DueDate { get; set; }

        // Navigation properties
        public virtual Book Book { get; set; }
        public virtual Users User { get; set; }
    }
}
