using Microsoft.AspNetCore.Mvc;
using MusicAudioPlayer.Models;
using System.Diagnostics;
using MusicAudioPlayer.Models.ViewModels;
using MusicAudioPlayer.Data;

namespace MusicAudioPlayer.Controllers
{
    public class HomeController : Controller
    {
/*        private readonly ILogger<HomeController> _logger;
*/
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            /*            ILogger<HomeController> logger,
             *            _logger = logger;
            */
            _context = context;
        }


        public IActionResult Index()

        {
            // Get playlists in DESC order
            var playlists = _context.Myplaylist.OrderByDescending(p => p.Id).ToList();

            var viewModel = new HomeMyplaylistViewModel
            {
                Myplaylist = playlists
            };

            return View(viewModel);
        }

       
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}