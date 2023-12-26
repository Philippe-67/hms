using Microsoft.AspNetCore.Mvc;

namespace NewHMS.Controllers
{
    public class UserAuthenticationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
