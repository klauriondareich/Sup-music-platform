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
        [Route("music/create")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Save a music in Db
        [Route("music/create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Id", "title", "author", "published", "file_path", "playId")] Music myMusic)
        {
            if (ModelState.IsValid)
            {
                _context.Add(myMusic);
                _context.SaveChanges();
                //return RedirectToAction("Display", "Playlist");
            }
            return View();
        }

        // GET: Display edit music view
        [Route("music/edit/{Id}")]
        public ActionResult Edit(int Id)
        {
            var myMusic = _context.Musics.FirstOrDefault(n => n.Id == Id)!;
            return View(myMusic);
        }

        // UPDATE: Edit a music
        [Route("music/edit/{Id}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int Id, [Bind("Id", "title", "author", "published", "file_path", "playId")] Music myMusic)
        {
            if (Id != myMusic.Id) return NotFound();

            if (!ModelState.IsValid) return View(myMusic);

            _context.Update(myMusic);
            _context.SaveChanges();
            return RedirectToAction("Display", "Playlist");
        }

        // DELETE: Delete a music
        public ActionResult Delete(int Id)
        {
            var myMusic = _context.Musics.FirstOrDefault(p => p.Id == Id);
            if (myMusic != null)
            {
                _context.Musics.Remove(myMusic);
                _context.SaveChanges();
                return RedirectToAction("Display", "Playlist");
            }
            return View(myMusic);
        }
    }
}
