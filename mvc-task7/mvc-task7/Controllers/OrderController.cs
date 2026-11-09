using Microsoft.AspNetCore.Mvc;
using mvc_task7.Data;
using mvc_task7.Models;
using Microsoft.EntityFrameworkCore;

namespace mvc_task7.Controllers
{
    
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _context;
        public OrderController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.orders
                .Include(p => p.Employee)
                .ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Employees = _context.employees.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Create(Order order)
        {
            _context.orders.Add(order);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Employees = _context.employees.ToList();
            return View(_context.orders.Find(id));
        }

        [HttpPost]
        public IActionResult Edit(Order order)
        {
            _context.orders.Update(order);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            return View(_context.orders
                .Include(p => p.Employee)
                .FirstOrDefault(p => p.Id == id));
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _context.orders.Remove(_context.orders.Find(id));
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
