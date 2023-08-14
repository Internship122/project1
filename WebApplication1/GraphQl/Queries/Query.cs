using HotChocolate;
using HotChocolate.Data;
using System.Data.Entity;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Services.Personnes;
using System.Threading.Tasks;
using WebApplication1.Services.Files;
using HotChocolate.Types;
using HotChocolate.AspNetCore;

namespace WebApplication1.GraphQl.Queries
{
    public class Query
    {
        public string Information => "this is a test";

    }
}
