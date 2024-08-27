using Microsoft.AspNetCore.Mvc;

namespace api_layer.Controllers
{
    public class LicenseClassController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
