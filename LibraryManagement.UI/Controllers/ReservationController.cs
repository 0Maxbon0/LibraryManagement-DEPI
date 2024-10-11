using LibraryManagement.DAL.Db;
using LibraryManagement.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.UI.Controllers
{
    public class ReservationController : Controller
    {
        private readonly UserManager<Users> userManager;
        private readonly AppDbContext dbContext;

        public ReservationController(UserManager<Users> userManager, AppDbContext dbContext)
        {
            this.userManager = userManager;
            this.dbContext = dbContext;
        }

        [HttpPost]
        public async Task<IActionResult> ReserveBook(int bookId)
        {
            var user = await userManager.GetUserAsync(User);
            if (user != null)
            {
                var book = dbContext.Books.FirstOrDefault(b => b.BookID == bookId);
                if (book != null && book.IsAvailable)
                {
                    var reservation = new Reservation
                    {
                        UserID = user.Id,
                        BookID = bookId,
                        ReservationDate = DateTime.Now,
                        IsActive = true
                    };

                    dbContext.Reservations.Add(reservation);
                    book.CopiesAvailable--;
                    await dbContext.SaveChangesAsync();

                    return RedirectToAction("Details", "Book", new { id = bookId });
                }
            }
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public async Task<IActionResult> CancelReservation(int reservationId)
        {
            var user = await userManager.GetUserAsync(User);
            if (user != null)
            {

                var reservation = dbContext.Reservations.FirstOrDefault(r => r.ReservationID == reservationId && r.UserID == user.Id);

                if (reservation != null)
                {
                    reservation.IsActive = false;
                    var book = dbContext.Books.FirstOrDefault(b => b.BookID == reservation.BookID);
                    if (book != null)
                    {
                        book.CopiesAvailable++;
                    }

                    await dbContext.SaveChangesAsync();
                    return RedirectToAction("MyReservations", "Account");
                }
            }
            return RedirectToAction("Login", "Account");
        }
    }
}
