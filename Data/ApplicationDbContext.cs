using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using projetASPC.Models;

namespace projetASPC.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Myplaylist> Myplaylist { get; set; }

        public DbSet<Music> Musics { get; set; }
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}