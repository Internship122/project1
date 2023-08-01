using WebApplication1.Data;
using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity.Core.Objects;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Linq;

namespace WebApplication1.Services.Personnes
{
    public class PersonneService : IPersonneService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
   
        public PersonneService(ApplicationDbContext db, IMapper mapper)
        {
            this._db = db;
            _mapper = mapper;
        }
        public async Task CreatePersonne(Personne personne)
        {
            await _db.Personnes.AddAsync(personne);
            var personDTO=_mapper.Map<Personne>(personne);
            
        }

      

        public async Task<IEnumerable<PersonneDTO>> GetAll()
        {
            //var configuration = new MapperConfiguration(cfg => cfg.CreateProjection<Personne, PersonneDTO>()
            //.ForMember(dto => dto.Age, conf => conf.MapFrom(p => p.Age(p.BirthDate))));

            var personnes= await _db.Personnes.
                 OrderBy(p => p.Name).
                 ThenBy(p => p.Prename).
                 ToListAsync();
            var personnesDTO= personnes.Select(personne=> _mapper.Map<PersonneDTO>(personne));
            return personnesDTO;
        }

        public async Task<PersonneDTO?> GetById(int id)
        {
            var personne = await _db.Personnes.FindAsync(id);
            if (personne == null)
            {
                return null;
            }
            var personDTO=_mapper.Map<PersonneDTO>(personne);
            return personDTO;
        }

        public async Task<PersonneDTO?> UpdatePersonne(int id)
        {
            var personne = await _db.Personnes.FindAsync(id);
            if (personne == null)
            {
                return null;
            }
            else
            { 
                var personDTO = _mapper.Map<PersonneDTO>(personne);
                return personDTO;
            }
        }

        public async Task<PersonneDTO?> DeletePersonne(int id)
        {
            var personne = await _db.Personnes.FindAsync(id);
            if (personne == null)
            {
                return null;
            }
            else
            {
                _db.Personnes.Remove(personne);
                var personDTO= _mapper.Map<PersonneDTO>(personne);
                return personDTO;
            }
        }

        public async Task Save()
        {
            await _db.SaveChangesAsync();
        }

        public bool AgeValidator (Personne personne,int MaxAge,int MinAge)
        {
            return ((personne.Age(personne.BirthDate) > MaxAge) || (personne.Age(personne.BirthDate) < MinAge));
            
        }
    }
}
