using Microsoft.AspNetCore.Mvc;
using hafta12_1.Models;
using Microsoft.EntityFrameworkCore;

namespace hafta12_1.Controllers
{
    public class StudentController : Controller
    {
        private readonly DataContext _context;
        public StudentController(DataContext context)
        {
            _context = context;   
        }
        public IActionResult Index()
        {
           var ogrencilistesi=_context.Students.ToList(); 
                      
            return View(ogrencilistesi);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View(new Student());
        }
        [HttpPost]
        public IActionResult Add(Student std)
        {
            _context.Students.Add(std); 
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            _context.Students.Remove(_context.Students.Find(id));
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var x=_context.Students.FirstOrDefault(x => x.Id == id);
            return View(x);
        }
        [HttpGet]
        public IActionResult List(int id)
        {
            var x = _context.Students
                            .Include(x=>x.DersBilgileri)
                            .ThenInclude(k=>k.Lesson)
                            .FirstOrDefault(x => x.Id == id);
            return View(x);
        }
        [HttpPost]
        public IActionResult Update(Student std)
        {
            var guncellenecek = _context.Students.FirstOrDefault(x => x.Id == std.Id);
            guncellenecek.Name = std.Name;
            guncellenecek.SurName = std.SurName;
            guncellenecek.Email = std.Email;

            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
