using AutoMapper;
using System.Text;
using WebApplication1.Models;

namespace WebApplication1.Profiles
{
    public class FileProfile:Profile
    {
        public FileProfile()
        {
            CreateMap<Models.File, FileDTO>()
            .ForMember(dest => dest.FileContent, opt => opt.MapFrom(src => Encoding.UTF8.GetString(src.FileData)));
        }
    }
}
