using AutoMapper;
using WebApplication1.Models;

namespace WebApplication1
{
    public class PersonnneProfile :Profile
    {
        public void PersonneProfile()
        {
            CreateMap<Personne, PersonneDTO>();
        }
    }
}
