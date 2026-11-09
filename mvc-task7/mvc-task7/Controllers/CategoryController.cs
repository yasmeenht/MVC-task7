using Microsoft.AspNetCore.Mvc;
using mvc_task7.Data;
using System.Net.WebSockets;
using mvc_task7.Models;

namespace mvc_task7.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.categories.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            _context.categories.Add(category);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(_context.categories.Find(id));
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            _context.Update(category);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            return View(_context.categories.Find(id));
        }

        public IActionResult Delete(int id)
        {
            var user = _context.categories.Find(id);
            _context.Remove(user);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
