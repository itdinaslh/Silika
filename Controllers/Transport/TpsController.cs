using Microsoft.AspNetCore.Mvc;
using Silika.Entity;
using Silika.Repository;
using Microsoft.EntityFrameworkCore;

namespace Silika.Controllers;

public class TpsController : Controller
{
    [HttpGet("/transport/tps")]
    public IActionResult Index()
    {
        return View("~/Views/Transport/Tps/Index.cshtml");
    }
}
