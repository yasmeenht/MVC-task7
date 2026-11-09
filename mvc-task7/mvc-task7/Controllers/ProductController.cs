using Microsoft.AspNetCore.Mvc;
using mvc_task7.Data;
using mvc_task7.Models;
using Microsoft.EntityFrameworkCore;

namespace mvc_task7.Controllers
{
    
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.products
                .Include(p => p.Category)
                .Include(p => p.Supplier)
                .ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Categories = _context.categories.ToList();
            ViewBag.Suppliers = _context.suppliers.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            _context.products.Add(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(_context.products.Find(id));
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            _context.products.Update(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            return View(_context.products
                .Include(p => p.Category)
                .Include(p => p.Supplier)
                .FirstOrDefault(p => p.Id == id));
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _context.products.Remove(_context.products.Find(id));
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
