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

        // GET: Display information of the playlist and musics inside it
        [Route("playlist/view/{Id}")]
        public IActionResult Display(int Id)

        {
            var playlistObj = _context.Myplaylist.FirstOrDefault(p => p.Id == Id);

            var musics = _context.Musics.Where(item => item.playId == Id).OrderByDescending(p => p.Id).ToList();

            if (playlistObj == null) return NotFound();

            var viewModel = new DisplayMusicViewModel{

                Myplaylist = playlistObj,
                Musics = musics,

            };

            return View(viewModel);
        }


        // GET: Display a create playlist view
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
            // Getting current user data
            var userName = User?.Identity?.Name;
            var user = _context.Users.FirstOrDefault(p => p.UserName == userName);
            if (user == null) return NotFound();


            if (ModelState.IsValid)
            {
                playlist.userId = user.Id;
                _context.Add(playlist);
                _context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        // GET: Display edit playlist view
        [Route("playlist/edit/{Id}")]
        public ActionResult Edit(int Id)
        {
            var playlist = _context.Myplaylist?.FirstOrDefault(n => n.Id == Id)!;
            return View(playlist);
        }

        // UPDATE: Edit a playlist and save new data in DB
        [Route("playlist/edit/{Id}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int Id, [Bind("Id", "title", "imagePath")] Myplaylist playlist)
        {
            if (Id != playlist.Id) return NotFound();

            if (!ModelState.IsValid) return View(playlist);
            // save userId when updated: Fix bug with this
            _context.Update(playlist);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        // DELETE: Delete a playlist
        public ActionResult Delete(int Id)
        {
            var playlist = _context.Myplaylist?.FirstOrDefault(p => p.Id == Id);
            if (playlist != null)
            {
                _context.Myplaylist.Remove(playlist);
                _context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View(playlist);
        }
    }
}
