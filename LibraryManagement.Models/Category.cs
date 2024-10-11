using System.Collections.Generic;

namespace LibraryManagement.Models
{
    public class Category
    {
        public int CategoryID { get; set; }  // Primary key for the Category table
        public string CategoryName { get; set; }  // The name of the category (e.g., Fiction, Non-fiction, History)

        // Navigation Property - A category can have many books
        public ICollection<Book> Books { get; set; }
    }
}
