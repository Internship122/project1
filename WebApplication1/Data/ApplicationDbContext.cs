using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)

        {
                
        }

        public DbSet<Personne> Personnes { get; set; } = null!;

        internal void Dispose(bool disposing)
        {
            throw new NotImplementedException();
        }

        internal Task<Personne> FindAsync(Personne personne)
        {
            throw new NotImplementedException();
        }
    }
}
