using BookLibrary.Data;
using BookLibrary.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookLibrary.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class PublisherController : Controller
    {
        private ApplicationDbContext _dbcontext;

        public PublisherController(ApplicationDbContext dbContext)
        {
            _dbcontext = dbContext;
        }
        public IActionResult Index()
        {
            var publishers = _dbcontext.Publisher.ToList();
            return View(publishers);
        }

        public IActionResult Details(int id)
        {

            var publisher = _dbcontext.Publisher.FirstOrDefault(x => x.Id == id);

            if (id == 0 || id == null || publisher == null) return NotFound();

            return View(publisher);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Publisher publisher)
        {
            if (ModelState.IsValid)
            {
                _dbcontext.Publisher.Add(publisher);
                _dbcontext.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(publisher);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (id == 0 || id == null) return NotFound();

            var publisher = _dbcontext.Publisher.FirstOrDefault(x => x.Id == id);

            if (publisher == null) return NotFound();

            return View(publisher);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            if (id == 0 || id == null) return NotFound();

            var publisher = _dbcontext.Publisher.FirstOrDefault(x => x.Id == id);

            if (publisher == null) return NotFound();

            _dbcontext.Publisher.Remove(publisher);
            _dbcontext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
