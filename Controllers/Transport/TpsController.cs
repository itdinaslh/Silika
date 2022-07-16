using Microsoft.AspNetCore.Mvc;
using Silika.Entity;
using Silika.Models;
using Silika.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace Silika.Controllers;

[Authorize]
public class TpsController : Controller
{
    [HttpGet("/transport/tps")]
    public IActionResult Index()
    {
        return View("~/Views/Transport/Tps/Index.cshtml");
    }

    [HttpGet("/transport/tps/create")]
    public IActionResult Create() {
        return PartialView("~/Views/Transport/Tps/AddEdit.cshtml", new TpsViewModel {
            Tps = new Tps()
        });
    }
}
