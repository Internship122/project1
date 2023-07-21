using WebApplication1.Models;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Services.Personnes;
using System.Data.Entity;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class PersonneController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private readonly IPersonneService _personneService;
   
        public PersonneController(IPersonneService personneService)
        {
            _personneService = personneService;
        }
       
        //private static PersonneDTO personneDTO(Personne personne)
        //{
        //    return new PersonneDTO
        //    {
        //        //Id = personne.Id,
        //        Name = personne.Name,
        //        Prename = personne.Prename,
        //        Age = personne.Age(personne.BirthDate)
        //    };
        //}
        
        //GET
        [HttpGet]
        public  async Task<ActionResult<IEnumerable<PersonneDTO>>> GetAll()
        {
            var PersonnesList= await _personneService.GetAll();
            //var PersonnesAvecAge =PersonnesList.Select(p => new PersonneDTO
            //{
            //    Name=p.Name,
            //    Prename=p.Prename,
            //    Age=p.Age(p.BirthDate)
            //});
            return Ok(PersonnesList);
        }

        

        //ADD
        [HttpPost]

        public  async Task<IActionResult> CreatePersonne(Personne personne)
        {
            if (_personneService.AgeValidator(personne, 150, 0))
            {
                return BadRequest("The person age is invalid");
            }
            else 
            {
                await _personneService.CreatePersonne(personne);
                await _personneService.Save();

                return Ok();
                
            };  
        }

    }
}
