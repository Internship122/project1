using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;
using File = WebApplication1.Models.File;
using System.Linq;
using System.Threading.Tasks;
//using System.Data.Entity;
using System.Collections.Generic;

namespace WebApplication1.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)

        {
                
        }

        public DbSet<Personne> Personnes { get; set; } = null!;

        public DbSet<File> Files { get; set; } = null!;

       
    }
}
