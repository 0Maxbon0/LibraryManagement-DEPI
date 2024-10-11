namespace LibraryManagement.Models
{
    public class Book
    {
        public int BookID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public string ISBN { get; set; }
        public int PublishedYear { get; set; }
        public int CopiesAvailable { get; set; }
        public int TotalCopies { get; set; }
        public string Description { get; set; }
        public string Publisher { get; set; }
        public required string CoverImageUrl { get; set; }
        public DateTime DateAdded { get; set; }
        public bool IsAvailable { get; set; }

        public int CategoryID { get; set; } // Foreign key for Category
        public Category Category { get; set; } // Navigation property for Category

        public ICollection<Review> Reviews { get; set; } // Navigation property for Reviews
        public ICollection<Reservation> Reservations { get; set; } // Navigation property for Reservations
        public ICollection<Checkout> Checkouts { get; set; } // Navigation property for Checkouts
        public decimal PenaltyAmount { get; set; }
        public DateTime DueDate { get; set; }
    }
}
