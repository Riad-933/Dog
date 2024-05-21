using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DogMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="BabatAdmin")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
