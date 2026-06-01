using hafta12_1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace hafta12_1.Controllers
{
    public class LessonController : Controller
    {
        private readonly DataContext _context;
        public LessonController(DataContext context) 
        {
            _context = context;
        }   
        public IActionResult Index()
        {
            return View(_context.Lessons.ToList());
        }
        public IActionResult Delete(int id)
        {
            var x= _context.Lessons.FirstOrDefault(k=>k.Id==id);
            _context.Lessons.Remove(x);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View(new Lesson());
        }

        [HttpPost]
        public IActionResult Add(Lesson lss)
        {
            _context.Lessons.Add(lss);
            _context.SaveChanges();
            return RedirectToAction("Index");   
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var k= _context.Lessons.FirstOrDefault(x=>x.Id==id);
            return View(k);
        }

        public IActionResult List(int id)
        {
            var veri = _context.Lessons
                                    .Include(x=>x.DersKa)
                                    .ThenInclude(f=>f.Student)
                                        .FirstOrDefault(f=>f.Id==id);
                            
                            
            return View(veri);
        }
        [HttpPost]
        public IActionResult Update(Lesson lss)
        {
            var k=_context.Lessons.FirstOrDefault(x=>x.Id==lss.Id);
            k.Code=lss.Code;
            k.Name = lss.Name;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
