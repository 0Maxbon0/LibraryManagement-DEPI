using Microsoft.AspNetCore.Mvc;
using LibraryManagement.BLL.Dtos;
using LibraryManagement.DAL.Db;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagement.Models;
using Microsoft.AspNetCore.Authorization;

namespace LibraryManagement.UI.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        private readonly AppDbContext _context;

        public BookController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var books = await _context.Books
                .Include(b => b.Checkouts) 
                .ThenInclude(c => c.Penalty) 
                .ToListAsync();

            var bookDtos = books.Select(book => new BookDtos
            {
                BookID = book.BookID,
                Title = book.Title,
                Author = book.Author,
                Genre = book.Genre,
                IsAvailable = book.IsAvailable,
                Description = book.Description,
            }).ToList();

            return View(bookDtos);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BookDtos model)
        {
            if (ModelState.IsValid)
            {
                var newBook = new Book
                {
                    Title = model.Title,
                    Author = model.Author,
                    Genre = model.Genre,
                    IsAvailable = model.IsAvailable,
                    DateAdded = DateTime.Now, 
                    CoverImageUrl = model.CoverImageUrl 
                };

                _context.Books.Add(newBook);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            foreach (var error in errors)
            {
                Console.WriteLine(error.ErrorMessage);  // Log the errors for debugging
            }

            return View(model); 
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null) return NotFound();

            var model = new BookDtos
            {
                BookID = book.BookID,
                Title = book.Title,
                Author = book.Author,
                Genre = book.Genre,
                IsAvailable = book.IsAvailable,
                CoverImageUrl = book.CoverImageUrl 
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(BookDtos model)
        {
            if (ModelState.IsValid)
            {
                var book = await _context.Books.FindAsync(model.BookID);
                if (book == null) return NotFound();

                book.Title = model.Title;
                book.Author = model.Author;
                book.Genre = model.Genre;
                book.IsAvailable = model.IsAvailable;
                book.CoverImageUrl = model.CoverImageUrl; 

                _context.Books.Update(book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model); 
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null) return NotFound();

            var model = new BookDtos
            {
                BookID = book.BookID,
                Title = book.Title,
                Author = book.Author,
                Genre = book.Genre,
                IsAvailable = book.IsAvailable,
                CoverImageUrl = book.CoverImageUrl
            };

            return View(model);
        }

        // Delete Book - POST
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
