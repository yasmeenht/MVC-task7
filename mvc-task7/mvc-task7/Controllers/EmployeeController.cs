using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mvc_task7.Data;
using mvc_task7.Models;

namespace mvc_task7.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.employees.Include(e => e.Orders).ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            _context.employees.Add(employee);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(_context.employees.Find(id));
        }

        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            _context.employees.Update(employee);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            return View(_context.employees.Find(id));
        }

        public IActionResult Delete(Employee employee)
        {
            _context.employees.Remove(employee);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
