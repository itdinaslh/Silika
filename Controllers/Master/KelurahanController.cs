using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Silika.Controllers;

public class KelurahanController : Controller {
    [HttpGet("/master/kelurahan")]
    public IActionResult Index() {
        return View("~/Views/Master/Kelurahan/Index.cshtml");
    }
}