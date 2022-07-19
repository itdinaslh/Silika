using Microsoft.AspNetCore.Mvc;
using Silika.Entity;
using Silika.Helpers;
using Silika.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace Silika.Controllers;

[Authorize]
public class LimbahB3Controller : Controller {

    private readonly ILimbahB3 repo;

    public LimbahB3Controller(ILimbahB3 repo) {
        this.repo = repo;
    }

    [HttpGet("/usaha/limbahb3")]
    public IActionResult Index() {
        return View("~/Views/Usaha/LimbahB3/Index.cshtml");
    }

    [HttpGet("/usaha/limbahb3/create")]
    public IActionResult Create() {
        return PartialView("~/Views/Usaha/LimbahB3/AddEdit.cshtml", new LimbahB3());
    }

    [HttpGet("/usaha/limbahb3/edit")]
    public async Task<IActionResult> Edit(int id) {
        LimbahB3? data = await repo.LimbahB3s.FirstOrDefaultAsync(l => l.LimbahB3Id == id);

        if (data is not null) {
            return PartialView("~/Views/Usaha/LimbahB3/AddEdit.cshtml", data);
        }

        return NotFound();
    }

    [HttpPost("/usaha/limbahb3/store")]
    public async Task<IActionResult> SaveDataAsync(LimbahB3 limbah) {
        if (ModelState.IsValid) {
            await repo.SaveDataAsync(limbah);

            return Json(Result.Success());
        }

        return PartialView("~/Views/Usaha/LimbahB3/AddEdit.cshtml", limbah);
    }

}