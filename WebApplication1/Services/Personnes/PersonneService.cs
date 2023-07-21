using WebApplication1.Data;
using WebApplication1.Models;
//using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity.Core.Objects;
using AutoMapper;
using AutoMapper.QueryableExtensions;

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
 
        }

      

        public async Task<IEnumerable<PersonneDTO>> GetAll()
        {
            var configuration = new MapperConfiguration(cfg => cfg.CreateProjection<Personne, PersonneDTO>()
            .ForMember(dto => dto.Age, conf => conf.MapFrom(p => p.Age(p.BirthDate))));

            return await _db.Personnes.
                 ProjectTo<PersonneDTO>(configuration).
                 OrderBy(p => p.Name).
                 ThenBy(p => p.Prename).
                 ToListAsync<PersonneDTO>();
        }

        public async Task Save()
        {
            await _db.SaveChangesAsync();
        }

        public bool AgeValidator (Personne personne,int MaxAge,int MinAge)
        {
            return (personne.Age(personne.BirthDate) > MaxAge) || (personne.Age(personne.BirthDate) < MinAge);
        }
    }
}
