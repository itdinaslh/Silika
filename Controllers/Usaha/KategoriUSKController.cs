using Microsoft.AspNetCore.Mvc;
using Silika.Entity;
using Silika.Helpers;
using Silika.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace Silika.Controllers;

[Authorize]
public class KategoriUSKController : Controller {
    private readonly IKategoriUSK repo;

    public KategoriUSKController(IKategoriUSK kat) => repo = kat;

    [HttpGet("/usaha/kategoriusk")]
    public IActionResult Index() {
        return View("~/Views/Usaha/KategoriUSK/Index.cshtml");
    }

    [HttpGet("/usaha/kategoriusk/create")]
    public IActionResult Create() {
        return PartialView("~/Views/Usaha/KategoriUSK/AddEdit.cshtml", new KategoriUSK());
    }

    [HttpGet("/usaha/kategoriusk/edit")]
    public async Task<IActionResult> Edit(int id) {
        KategoriUSK? data = await repo.KategoriUSKs.FirstOrDefaultAsync(k => k.KategoriUSKId == id);

        if (data is not null) {
            return PartialView("~/Views/Usaha/KategoriUSK/AddEdit.cshtml", data);
        }

        return NotFound();
    }

    [HttpPost("/usaha/kategoriusk/store")]
    public async Task<IActionResult> SaveDataAsync(KategoriUSK model) {
        if (ModelState.IsValid) {
            await repo.SaveDataAsync(model);

            return Json(Result.Success());
        }

        return PartialView("~/Views/Usaha/KategoriUSK/AddEdit.cshtml", model);
    }
}