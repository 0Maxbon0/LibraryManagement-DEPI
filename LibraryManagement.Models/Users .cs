using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace LibraryManagement.Models
{
    public class Users : IdentityUser
    {
        public int UserID { get; set; }
        public string FullName { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool IsActive { get; set; }

        // Navigation properties
        public ICollection<Checkout> Checkouts { get; set; }
        public ICollection<Penalty> Penalties { get; set; }
        public ICollection<Reservation> Reservations { get; set; } // Add this line

        public Users()
        {
            Checkouts = new List<Checkout>();
            Penalties = new List<Penalty>();
            Reservations = new List<Reservation>(); // Initialize the collection
        }
    }
}
