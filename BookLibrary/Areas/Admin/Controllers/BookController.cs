using BookLibrary.Data;
using BookLibrary.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookLibrary.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class BookController : Controller
    {
        private ApplicationDbContext _dbcontext;

        public BookController(ApplicationDbContext dbContext)
        {
            _dbcontext = dbContext;
        }
        public IActionResult Index()
        {
            var books = _dbcontext.Book.ToList();

            Author author = new Author();

            return View(books);
        }

        public IActionResult Details(int id)
        {
            if (id == 0 || id == null) return NotFound();

            var book = _dbcontext.Book.FirstOrDefault(x => x.Id == id);
            if (book == null) return NotFound();

            return View(book);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Authors = _dbcontext.Author.Select(a => new SelectListItem()
            {
                Value = a.Id.ToString(),
                Text = a.Name
            }).ToList();

            ViewBag.Publishers = _dbcontext.Publisher.Select(p => new SelectListItem()
            {
                Value = p.Id.ToString(),
                Text = p.PublisherName
            }).ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                _dbcontext.Book.Add(book);
                _dbcontext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            ViewBag.Authors = _dbcontext.Author.Select(a => new SelectListItem()
            {
                Value = a.Id.ToString(),
                Text = a.Name
            }).ToList();

            ViewBag.Publishers = _dbcontext.Publisher.Select(p => new SelectListItem()
            {
                Value = p.Id.ToString(),
                Text = p.PublisherName
            }).ToList();

            return View(book);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var book = _dbcontext.Book.FirstOrDefault(b => b.Id == id);

            if (book == null) return NotFound();

            return View(book);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            if (id == 0 || id == null) return NotFound();

            var book = _dbcontext.Book.FirstOrDefault(b =>b.Id == id);
            
            if (book == null) return NotFound();

            _dbcontext.Remove(book);
            _dbcontext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
