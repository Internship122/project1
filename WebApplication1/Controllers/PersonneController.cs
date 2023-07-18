using AspNetCore;
using WebApplication1.Models;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Services.Personnes;
using Microsoft.EntityFrameworkCore;


namespace WebApplication1.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class PersonneController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private readonly IPersonneService _personneService;
        

        public PersonneController(ApplicationDbContext db)
        {
            _db = db;
        }

        public PersonneController(IPersonneService personneService)
        {
            _personneService = personneService;
        }
       
        private static PersonneDTO personneDTO(Personne personne)
        {
            return new PersonneDTO
            {
                //Id = personne.Id,
                Name = personne.Name,
                Prename = personne.Prename,
                Age = personne.Age(personne.BirthDate)
            };
        }
        
        //GET
        [HttpGet]
        public  Task<ActionResult<IEnumerable<Personne>>> GetAll()
        {
            var PersonneList= _personneService.GetAll();
            return PersonneList;
        }

        

        //ADD
        [HttpPost]
        [ValidateAntiForgeryToken]

        public  ActionResult<PersonneDTO> CreatePersonne(Personne personne)
        {
            if ((personne.Age(personne.BirthDate) > 150) || (personne.Age(personne.BirthDate) < 0))
            {
                return BadRequest();
            }
            else
            {
                _personneService.CreatePersonne(personne);
            
            return CreatedAtAction(
                nameof(Personne)
                , new {id= personne.Id}, personne);
            }
        }
        //Update
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonne(string name, PersonneDTO personneDTO)
        {
            if (name != personneDTO.Name)
            {
                return BadRequest();
            }

            var personne = await _db.Personnes.FindAsync(name);
            if (personne == null)
            {
                return NotFound();
            }

            personneDTO.Name = personne.Name;
            personneDTO.Prename = personne.Prename;
            personneDTO.Age = personne.Age(personne.BirthDate);

            try
            {
                _personneService.PutPersonne(personne);
            }
            catch (DbUpdateConcurrencyException) 
            {
                return NotFound();
            }

            return NoContent();
        }








    }
}
