using Microsoft.AspNetCore.Mvc;
using MusicAudioPlayer.Models;
using MusicAudioPlayer.Data;

namespace MusicAudioPlayer.Controllers
{
    public class MusicController : Controller
    {
        // CRUD for musics inside the playlist

        private readonly ApplicationDbContext _context;

        public MusicController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Display a create music view
        [Route("music/create/{playlistId}")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Save a music in Db
        [Route("music/create/{playlistId}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int playlistId, [Bind("Id", "title", "author", "published", "file_path")] Music myMusic)
        {
            if (ModelState.IsValid)
            {
                myMusic.playId = playlistId;
                _context.Add(myMusic);
                _context.SaveChanges();
                return RedirectToAction("Display", "Playlist", new { Id = playlistId });
            }
            return View();
        }

        // GET: Display edit music view
        [Route("music/edit/{playlistId}/{Id}")]
        public ActionResult Edit(int Id)
        {
            var myMusic = _context.Musics.FirstOrDefault(n => n.Id == Id)!;
            return View(myMusic);
        }

        // UPDATE: Edit a music

        [Route("music/edit/{playlistId}/{Id}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int Id, int playlistId, [Bind("Id", "title", "author", "published", "file_path")] Music myMusic)
        {
            if (Id != myMusic.Id) return NotFound();

            if (!ModelState.IsValid) return View(myMusic);

            myMusic.playId = playlistId;

            _context.Update(myMusic);
            _context.SaveChanges();

            myMusic.playId = playlistId;

            return RedirectToAction("Display", "Playlist", new {Id = playlistId});
        }

        // DELETE: Delete a music
        public ActionResult Delete(int Id, int playlistId)
        {
            var myMusic = _context.Musics.FirstOrDefault(p => p.Id == Id);
            if (myMusic != null)
            {
                _context.Musics.Remove(myMusic);
                _context.SaveChanges();
            }
            return RedirectToAction("Display", "Playlist", new { Id = playlistId });

        }
    }
}
