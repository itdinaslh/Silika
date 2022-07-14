using Microsoft.AspNetCore.Mvc;
using Silika.Repository;
using Silika.Entity;
using Silika.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Silika.Controllers;

public class StatusLahanController : Controller
{
    private readonly IStatusLahan repo;

    public StatusLahanController(IStatusLahan repo)
    {
        this.repo = repo;
    }

    [HttpGet("/master/status-lahan")]
    public IActionResult Index()
    {
        return View("~/Views/Master/StatusLahan/Index.cshtml");
    }

    [HttpGet("/master/status-lahan/create")]
    public IActionResult Create()
    {
        return PartialView("~/Views/Master/StatusLahan/AddEdit.cshtml", new StatusLahan());
    }

    [HttpGet("/master/status-lahan/edit")]
    public async Task<IActionResult> Edit(int id)
    {
        StatusLahan? data = await repo.StatusLahans.FirstOrDefaultAsync(s => s.StatusLahanId == id);

        if (data is not null)
        {
            return PartialView("~/Views/Master/StatusLahan/AddEdit.cshtml", data);
        }

        return NotFound();
    }

    [HttpPost("/master/status-lahan/store")]
    public async Task<IActionResult> SaveDataAsync(StatusLahan status)
    {
        if (ModelState.IsValid)
        {
            await repo.SaveDataAsync(status);

            return Json(Result.Success());
        }

        return PartialView("~/Views/Master/StatusLahan/AddEdit.cshtml", status);
    }
}