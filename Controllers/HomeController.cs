using Microsoft.AspNetCore.Mvc;
using projetASPC.Models;
using System.Diagnostics;
using projetASPC.Models.ViewModels;
using projetASPC.Data;

namespace projetASPC.Controllers
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
            
            var playlists = _context.Myplaylist.ToList();

            /*var playlists = new List<Myplaylist>{

                new Myplaylist { Id = 1, title = "Ma chanson du moment", imagePath="images/albums/img2.jpg"},
                new Myplaylist { Id = 2, title = "Wenge music", imagePath="images/picture.jpg"},
                new Myplaylist { Id = 3, title = "Sur ma route", imagePath="images/picture.jpg"}
            };*/

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