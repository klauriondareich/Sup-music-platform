using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MusicAudioPlayer.Models;

namespace MusicAudioPlayer.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Myplaylist> Myplaylist { get; set; }

        public DbSet<Music> Musics { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}