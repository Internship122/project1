using HotChocolate;
using HotChocolate.Data;
using System.Data.Entity;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Services.Personnes;
using System.Threading.Tasks;
using WebApplication1.Services.Files;
using HotChocolate.Types;

namespace WebApplication1.GraphQl
{
    public class Query
    {
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public async Task<IEnumerable<PersonneDTO>> GetPersonnes([Service] IPersonneService personneService)
        {
            return await personneService.GetAll();
        }
        public async Task<PersonneDTO?> GetPersonneById(int id,[Service] IPersonneService personneService)
        {
            return await personneService.GetById(id);
        }
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public async Task<IEnumerable<Models.File?>> GetFiles([Service] IFileService fileService)
        {
            return await fileService.GetAllFiles();
        }
        public async Task<Models.File?> GetFileByFilename(string fileName, [Service] IFileService fileService)
        {
            return await fileService.GetFileByName(fileName);
        }
    }
}
