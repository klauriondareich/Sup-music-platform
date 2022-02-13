using Microsoft.AspNetCore.Identity;

namespace MusicAudioPlayer.Models
{
    public class Myplaylist
    {
         public int Id {get; set;}
        public string? title {get; set;}
        public string? imagePath {get; set;}

       /* public virtual IdentityUser? User {get; set;}
        public string? userId {get; set; }*/
    }
}
