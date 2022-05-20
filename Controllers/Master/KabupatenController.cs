using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;

namespace Silika.Controllers;

[Authorize(Roles = "SysAdmin, SilikaAdmin")]
public class KabupatenController : Controller {
    [HttpGet("/master/kabupaten")]
    public IActionResult Index() {
        return View("~/Views/Master/Kabupaten/Index.cshtml");
    }
}