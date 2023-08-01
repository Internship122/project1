using WebApplication1.Models;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Services.Personnes;
using System.Data.Entity;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace WebApplication1.Controllers
{
    [Route("Personneapi/[Controller]")]
    [ApiController]
    //[Area("PersonneController")]
    public class PersonneController : ControllerBase
    {
        private readonly IPersonneService _personneService;

        public PersonneController(IPersonneService personneService)
        {
            _personneService = personneService;
        }


        //GET
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonneDTO>>> GetAll()
        {
            var PersonnesList = await _personneService.GetAll();
            return Ok(PersonnesList);
        }

        //GETBYID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var personneDTO = await _personneService.GetById(id);
            if (personneDTO == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(personneDTO);
            }
            
        }

        //UPDATE
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePersonne(int id)
        {
            var UpdatedPersonne = await _personneService.UpdatePersonne(id);
            if (UpdatedPersonne == null)
            {
                return NotFound();
            }
            else 
            {
                await _personneService.Save();
                return Ok(UpdatedPersonne);
            }
        }

        //ADD
        [HttpPost]

        public async Task<IActionResult> CreatePersonne(Personne personne)
        {
            try
            {
                if (_personneService.AgeValidator(personne, 150, 0))
                {
                    return BadRequest("The person age is invalid");
                }
                else
                    {
                    await _personneService.CreatePersonne(personne);
                    await _personneService.Save();

                    return Ok(personne);

                }
            }   
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonne(int id)
        {
            var DeletedPersonne= await _personneService.DeletePersonne(id);
            if (DeletedPersonne == null)
            {
                return NotFound();
            }
            else
            {
                await _personneService.Save();
                return NoContent();
            }
            
        }
    }
}
    