using LibraryManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using LibraryManagement.DAL.Db;

public class ReviewController : Controller
{
    private readonly UserManager<Users> userManager;
    private readonly AppDbContext dbContext;

    public ReviewController(UserManager<Users> userManager, AppDbContext dbContext)
    {
        this.userManager = userManager;
        this.dbContext = dbContext;
    }

    [HttpPost]
    public async Task<IActionResult> AddReview(Review review)
    {
        if (ModelState.IsValid)
        {
            var user = await userManager.GetUserAsync(User); // Get the logged-in user
            if (user != null)
            {
                review.UserID = user.Id; // Associate the review with the current user
                review.DatePosted = DateTime.Now;
                dbContext.Reviews.Add(review);
                await dbContext.SaveChangesAsync();
                return RedirectToAction("Details", "Book", new { id = review.BookID });
            }
        }
        return View(review);
    }
}
