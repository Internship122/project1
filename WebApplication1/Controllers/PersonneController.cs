using AspNetCore;
using WebApplication1.Models;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Services.Personnes;
using Microsoft.EntityFrameworkCore;


namespace WebApplication1.Controllers
{
    [ApiController]
    public class PersonneController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly DateTime BirthDate;
        private readonly IPersonneService _personneService;
        

        public PersonneController(ApplicationDbContext db)
        {
            _db = db;
        }

        public PersonneController(IPersonneService personneService) 
        { 
            _personneService = personneService;
        }

        public IActionResult Index()
        {
            IEnumerable<Personne> objPersonList = _db.Personnes;   
            return View(objPersonList);
        }
        //GET
        [HttpGet]
        public IActionResult GetAll()
        {
            //_db.Entry<Personne>(personne).State = EntityState.Modified;
            //try
            //{
            //    await _db.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException) 
            //{
            //    throw;
            //}
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public async IActionResult Add(Personne obj)
        {
            _personneService.Add(obj);
            if (Personne.Age(BirthDate) >= 150 && Personne.Age(BirthDate) < 0)
            {
                ModelState.AddModelError("BirthDate", "Birthdate invalid ");

            }
            if (ModelState.IsValid) { 
            _db.Personnes.Add(obj);
                await _db.SaveChangesAsync();
            return RedirectToAction("Index","Personne");
            }
            //return View(obj);
        }
    }
}
