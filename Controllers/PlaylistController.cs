using Microsoft.AspNetCore.Mvc;
using MusicAudioPlayer.Data;
using MusicAudioPlayer.Models.ViewModels;


namespace MusicAudioPlayer.Controllers
{
    public class PlaylistController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PlaylistController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Route("playlist/view/{Id}")]
        public IActionResult Display(int Id)

        {
            var playlistObj = _context.Myplaylist.FirstOrDefault(p => p.Id == Id);

            var musics = _context.Musics.Where(item => item.Id == Id).ToList();

            if (playlistObj == null) return NotFound();

            var viewModel = new DisplayMusicViewModel{
                Myplaylist = playlistObj,
                Musics = musics
            };

            return View(viewModel);
        }
    }
}
