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
        //public DbSet<Category> Categories { get; set; }
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

            
        }
    }
}
