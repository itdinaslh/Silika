using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Silika.Controllers;

[Authorize(Roles = "SysAdmin, SilikaAdmin")]
public class KecamatanController : Controller {
    [HttpGet("/master/kecamatan")]
    public IActionResult Index() {
        return View("~/Views/Master/Kecamatan/Index.cshtml");
    }
}