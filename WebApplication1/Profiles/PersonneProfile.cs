using AutoMapper;
using WebApplication1.Models;

namespace WebApplication1.Profiles
{
    public class PersonneProfile : Profile
    {
        public  PersonneProfile()
        {
            CreateMap<Personne, PersonneDTO>()
            .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.Age(src.BirthDate)));

        }
        

    }
}
