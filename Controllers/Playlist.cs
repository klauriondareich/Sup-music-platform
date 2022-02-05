using Microsoft.AspNetCore.Mvc;

namespace projetASPC.Controllers
{
    public class Playlist : Controller
    {
        [Route("playlist/view/{Id}")]
        public IActionResult Display(int Id)
        {
            return View(Id);
        }
    }
}
