using Microsoft.AspNetCore.Mvc;
using MusicAudioPlayer.Data;
using MusicAudioPlayer.Models.ViewModels;
using MusicAudioPlayer.Models;


namespace MusicAudioPlayer.Controllers
{
    public class PlaylistController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PlaylistController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Display all playlists
        [Route("playlist/view/{Id}")]
        public IActionResult Display(int Id)

        {
            var playlistObj = _context.Myplaylist.FirstOrDefault(p => p.Id == Id);

            var musics = _context.Musics.Where(item => item.playId == Id).ToList();

            if (playlistObj == null) return NotFound();

            var viewModel = new DisplayMusicViewModel{
                Myplaylist = playlistObj,
                Musics = musics
            };

            return View(viewModel);
        }


        // GET: PlaylistController/Create
        [Route("playlist/create")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Save a playlist in Db
        [Route("playlist/create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Id", "title", "imagePath")] Myplaylist playlist)
        {
            if (ModelState.IsValid)
            {
                _context.Add(playlist);
                _context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        // GET: PlaylistController/Edit
        [Route("playlist/edit/{Id}")]
        public ActionResult Edit(int Id)
        {
            var playlist = _context.Myplaylist.FirstOrDefault(n => n.Id == Id)!;
            return View(playlist);
        }

        // POST: Edit a playlist
        [Route("playlist/edit/{Id}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int Id, [Bind("Id", "title", "imagePath")] Myplaylist playlist)
        {
            if (Id != playlist.Id) return NotFound();

            if (!ModelState.IsValid) return View(playlist);

            _context.Update(playlist);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

    }
}
