using Microsoft.AspNetCore.Mvc;

namespace api_layer.Controllers
{
    public class TestTypeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
