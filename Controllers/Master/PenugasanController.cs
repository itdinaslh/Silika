using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Silika.Entity;
using Silika.Repository;
using Silika.Helpers;

namespace Silika.Controllers.Master;

public class PenugasanController : Controller
{
    private readonly IPenugasan repo;

    public PenugasanController(IPenugasan repo)
    {
        this.repo = repo;
    }

    [HttpGet("/master/penugasan")]
    public IActionResult Index()
    {
        return View("~/Views/Master/Penugasan/Index.cshtml");
    }

    [HttpGet("/master/penugasan/create")]
    public IActionResult Create()
    {
        return PartialView("~/Views/Master/Penugasan/AddEdit.cshtml", new Penugasan());
    }

    [HttpGet("/master/penugasan/edit")]
    public async Task<IActionResult> Edit(int id)
    {
        Penugasan? data = await repo.Penugasans.FirstOrDefaultAsync(p => p.PenugasanId == id);

        return PartialView("~/Views/Master/Penugasan/AddEdit.cshtml", data);
    }

    [HttpPost("/master/penugasan/store")]
    public async Task<IActionResult> SaveDataAsync(Penugasan tugas)
    {
        if (ModelState.IsValid)
        {
            await repo.SaveDataAsync(tugas);

            return Json(Result.Success());
        }

        return PartialView("~/Views/Master/Penugasan/AddEdit.cshtml", tugas);
    }
}
