using hafta12_1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.Xml;

namespace hafta12_1.Controllers
{
    public class RegisterController : Controller
    {
        private readonly DataContext _context;
        public RegisterController(DataContext context)
        {
            _context = context;                
        }
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Ogrenciler =new SelectList(_context.Students.ToList(),"Id","Name");
            ViewBag.Dersler =new SelectList(_context.Lessons.ToList(),"Id","Name");
            return View();
        }
        [HttpPost]
        public IActionResult Index(Register res)
        {
            res.Date = DateTime.Now;    
            _context.Registers.Add(res);    
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult List()
        {
            var ders = _context.Registers
                                .Include(x => x.Student)
                                .Include(y => y.Lesson)
                                .ToList();
            return View(ders);
        }
        public IActionResult Delete(int id)
        {
            _context.Registers.Remove(_context.Registers.FirstOrDefault(x => x.Id == id));
            _context.SaveChanges();

            return RedirectToAction("List");
        }
        public IActionResult Update(int id)
        {
            var k = _context.Registers.FirstOrDefault(x=>x.Id==id);
            //ViewBag.Ogrenci = k.Student.Name;
            ViewBag.OgrId = k.StudentId;

            //ViewBag.Ders = k.Lesson.Name;
            ViewBag.DersId = k.LessonId;
            return View(k);
        }
    }
}
