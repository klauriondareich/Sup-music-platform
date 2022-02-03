using Microsoft.AspNetCore.Mvc;

namespace projetASPC.Controllers
{
    public class Playlist : Controller
    {
        [Route("playlist/view")]
        public IActionResult Display()
        {
            return View();
        }
    }
}
