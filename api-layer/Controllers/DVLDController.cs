using Microsoft.AspNetCore.Mvc;

namespace api_layer.Controllers
{
    public class DVLDController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
