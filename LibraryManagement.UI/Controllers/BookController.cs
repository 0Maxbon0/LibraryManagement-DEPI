using Microsoft.AspNetCore.Mvc;
using LibraryManagement.BLL.Dtos;
using LibraryManagement.DAL.Db;
using Microsoft.EntityFrameworkCore;
using LibraryManagement.Models;
using Microsoft.AspNetCore.Authorization;
using LibraryManagement.UI.Models.ActionRequest;

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

            var bookmodel = books.Select(book => new Book
            {
                BookID = book.BookID,
                Title = book.Title,
                Author = book.Author,
                Genre = book.Genre,
                IsAvailable = book.IsAvailable,
                Description = book.Description,
                Image = book.Image,
            }).ToList();

            return View(bookmodel);
        }
        public string UploadFile(IFormFile file, string destinationFolder)
        {
            string uniqueFileName = string.Empty;

            if (file != null && file.Length > 0)
            {
                string uploadsFolder = Path.Combine(@"./wwwroot/", destinationFolder);
                uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBookActionRequest model)
        {

            string uniqueFileName = UploadFile(model.Image, "Images");

            if (ModelState.IsValid)
            {
                var newBook = new Book
                {
                    Title = model.Title,
                    Author = model.Author,
                    Genre = model.Genre,
                    IsAvailable = model.IsAvailable,
                    DateAdded = DateTime.Now, 
                    Description = model.Description,
                    Image = uniqueFileName
                };

                _context.Books.Add(newBook);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            foreach (var error in errors)
            {
                Console.WriteLine(error.ErrorMessage);  
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
                Description = book.Description,
                IsAvailable = book.IsAvailable

};

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(BookDtos model)
        {
            if (ModelState.IsValid)
            {
                var book = await _context.Books.FindAsync(model.BookID);
                Console.WriteLine(model.BookID);
                if (book == null) return NotFound();
                book.Title = model.Title;
                book.Author = model.Author;
                book.Genre = model.Genre;
                book.IsAvailable = model.IsAvailable;
                book.Description = model.Description;
            

                _context.Books.Update(book);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Book");

            }
            return NotFound(); ; 
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Console.WriteLine($"Received ID: {id}");

            var book = await _context.Books.FindAsync(id);
            if (book == null) return NotFound();

            var model = new Book
            {
                BookID = book.BookID,
                Title = book.Title,
                Author = book.Author,
                Genre = book.Genre,
                IsAvailable = book.IsAvailable,
                Image = book.Image
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Console.WriteLine($"Received ID: {id}");
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Book");

            }
            return NotFound();
        }
    }
}
