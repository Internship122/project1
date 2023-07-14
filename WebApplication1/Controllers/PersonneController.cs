//using AspNetCore;
using WebApplication1.Models;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;


namespace WebApplication1.Controllers
{
    [ApiController]
    public class PersonneController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly DateTime BirthDate;

        public PersonneController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Personne> objPersonList = _db.Personnes;   
            return View(objPersonList);
        }
        //GET
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public IActionResult Add(Personne obj)
        {
            if (Personne.Age(BirthDate) >= 150 && Personne.Age(BirthDate) < 0)
            {
                ModelState.AddModelError("BirthDate", "Birthdate invalid ");

            }
            if (ModelState.IsValid) { 
            _db.Personnes.Add(obj);
                _db.SaveChanges();
            return RedirectToAction("Index","Personne");
            }
            return View(obj);
        }
    }
}
