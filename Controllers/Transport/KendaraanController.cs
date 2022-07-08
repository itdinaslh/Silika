using Microsoft.AspNetCore.Mvc;

namespace Silika.Controllers
{
    public class KendaraanController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Views/Transport/Kendaraan/Index.cshtml");
        }

        [HttpGet("/transport/kendaraan/create")]
        public IActionResult Create()
        {
            return PartialView("~/Views/Transport/Kendaraan/AddEdit.cshtml");
        }
    }
}
