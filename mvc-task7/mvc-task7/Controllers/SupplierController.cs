using Microsoft.AspNetCore.Mvc;
using mvc_task7.Data;
using mvc_task7.Models;

namespace mvc_task7.Controllers
{
    public class SupplierController : Controller
    {
        private readonly ApplicationDbContext _context;
        public SupplierController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.suppliers.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Supplier supplier)
        {
            _context.suppliers.Add(supplier);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(_context.suppliers.Find(id));
        }

        [HttpPost]
        public IActionResult Edit(Supplier supplier)
        {
            _context.suppliers.Update(supplier);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            return View(_context.suppliers.Find(id));
        }

        public IActionResult Delete(Supplier supplier)
        {
            _context.suppliers.Remove(supplier);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
