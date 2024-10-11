using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using LibraryManagement.Models;

namespace LibraryManagement.DAL.Db
{
    public class AppDbContext : IdentityDbContext<Users>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Checkout> Checkouts { get; set; }
        public DbSet<Penalty> Penalties { get; set; }
        public DbSet<Return> Returns { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuring Checkout relationships
            modelBuilder.Entity<Checkout>()
                .HasOne(c => c.Book)
                .WithMany(b => b.Checkouts)
                .HasForeignKey(c => c.BookID);

            modelBuilder.Entity<Checkout>()
                .HasOne(c => c.Users)
                .WithMany(u => u.Checkouts)
                .HasForeignKey(c => c.UserID);

            modelBuilder.Entity<Penalty>()
                .HasOne(p => p.Checkout)
                .WithMany(c => c.Penalties)
                .HasForeignKey(p => p.CheckoutID);

            modelBuilder.Entity<Return>()
                .HasOne(r => r.Checkout)
                .WithMany(c => c.Returns)
                .HasForeignKey(r => r.CheckoutID);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.User)
                .WithMany(u => u.Reservations)
                .HasForeignKey(r => r.UserID);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Book)
                .WithMany(b => b.Reservations)
                .HasForeignKey(r => r.BookID);

            // Seed Book Data
            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    BookID = 1,
                    Title = "Artificial Intelligence",
                    Author = "John McCarthy",
                    Genre = "Technology",
                    ISBN = "978-1234567890",
                    PublishedYear = 2020,
                    CopiesAvailable = 5,
                    TotalCopies = 10,
                    Description = "An in-depth look into AI.",
                    Publisher = "Tech Books",
                    CoverImageUrl = "~/images/ai.jpg",
                    DateAdded = DateTime.Now,
                    IsAvailable = true,
                    CategoryID = 1 // Ensure Category with ID 1 exists
                },
                new Book
                {
                    BookID = 2,
                    Title = "Computer Science Fundamentals",
                    Author = "Jane Doe",
                    Genre = "Education",
                    ISBN = "978-0987654321",
                    PublishedYear = 2018,
                    CopiesAvailable = 2,
                    TotalCopies = 5,
                    Description = "Basic principles of computer science.",
                    Publisher = "Edu Books",
                    CoverImageUrl = "~/images/cs.jpg",
                    DateAdded = DateTime.Now,
                    IsAvailable = true,
                    CategoryID = 2 // Ensure Category with ID 2 exists
                },
                new Book
                {
                    BookID = 3,
                    Title = "Algorithm Design",
                    Author = "Robert Sedgewick",
                    Genre = "Education",
                    ISBN = "978-1111111111",
                    PublishedYear = 2019,
                    CopiesAvailable = 3,
                    TotalCopies = 8,
                    Description = "A comprehensive guide to algorithm design.",
                    Publisher = "Algo Press",
                    CoverImageUrl = "~/images/algo.jpg",
                    DateAdded = DateTime.Now,
                    IsAvailable = true,
                    CategoryID = 2 // Ensure Category with ID 2 exists
                }
            );

            // Seed Category Data (optional)
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryID = 1, CategoryName = "Technology" },
                new Category { CategoryID = 2, CategoryName = "Education" }
            );

            // You can also seed other entities like Reservation, Review, etc. if needed.
        }
    }
}
