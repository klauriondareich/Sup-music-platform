using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MusicAudioPlayer.Models;

namespace MusicAudioPlayer.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        /*protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityUser>()
                .HasMany<Myplaylist>()
                .WithMany(p => p.User)
                .HasForeignKey(p => p.userId);
        }*/

        public DbSet<Myplaylist> Myplaylist { get; set; }

        public DbSet<Music> Musics { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

       
    }
}