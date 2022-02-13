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
            List<Myplaylist> playlists = new List<Myplaylist>();

           
            if ((bool)(User?.Identity?.IsAuthenticated))
            {
                // Getting current user data
                var userName = User?.Identity?.Name;
                var user = _context.Users.FirstOrDefault(p => p.UserName == userName);

                // Get all playlists of a User in DESC order (From recent to the last)
                 playlists = _context.Myplaylist?.Where(item => item.userId == user.Id).OrderByDescending(p => p.Id).ToList();
            }
          
            

            var viewModel = new HomeMyplaylistViewModel
            {
                Myplaylist = playlists
            };

            return View(viewModel);
        }

       
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}