using BookLibrary.Data;
using BookLibrary.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace BookLibrary.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AuthorController : Controller
    {
        private ApplicationDbContext _dbcontext;

        public AuthorController(ApplicationDbContext dbContext)
        {
            _dbcontext = dbContext;
        }
        public IActionResult Index()
        {
            var authors = _dbcontext.Author.ToList();

            return View(authors);
        }

        public IActionResult Details(int id)
        {
            var author = _dbcontext.Author.FirstOrDefault(a => a.Id == id);

            ViewBag.Books = _dbcontext.Book.FirstOrDefault(a => a.AuthorId == id);

            return View(author);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Author author)
        {
            if(ModelState.IsValid)
            {
                _dbcontext.Author.Add(author);
                _dbcontext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(author);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            if(id == 0 || id == null) return NotFound();

            var author = _dbcontext.Author.FirstOrDefault(a => a.Id == id);

            if (author == null) return NotFound();

            return View(author);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            if (id == 0 || id == null) return NotFound();

            var author = _dbcontext.Author.FirstOrDefault(a => a.Id == id);

            if (author == null) return NotFound();

            _dbcontext.Author.Remove(author);
            _dbcontext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}