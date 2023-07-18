using AspNetCore;
using WebApplication1.Models;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Services.Personnes;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace WebApplication1.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class PersonneController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private readonly IPersonneService _personneService;
        private IMapper _mapper;
        private bool disposing;


        public PersonneController(IMapper mapper)
        {
            _mapper = mapper;
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
            if ((personne.Age(personne.BirthDate) > 150) && (personne.Age(personne.BirthDate) < 0))
            {
                return BadRequest();;
            }
            else 
            {
                _personneService.CreatePersonne(personne);
                _personneService.Save();
            
                return CreatedAtAction(
                nameof(Personne)
                , new {id= personne.Id}, personne);
            }  
        }

        public void Dispose(bool disposing)
        {
            _personneService.Dispose();
        }
    }
}
