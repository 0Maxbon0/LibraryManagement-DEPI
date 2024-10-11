using System;

namespace LibraryManagement.Models
{
    public class Review
    {
        public int ReviewID { get; set; }  // Primary key for the Review entity
        public int BookID { get; set; }  // Foreign key to associate with the Book entity
        public string UserID { get; set; }  // Foreign key to associate with the User who wrote the review
        public string Content { get; set; }  // The content of the review
        public int Rating { get; set; }  // Rating out of 5
        public DateTime DatePosted { get; set; }  // Date the review was posted

        // Navigation Properties
        public Book Book { get; set; }  // Navigation property to the Book entity
        public Users User { get; set; }  // Navigation property to the User entity
    }
}
