using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Silika.Entity;
using Silika.Repository;
using Silika.Helpers;
using Silika.Models;

namespace Silika.Controllers;

[Authorize(Roles = "SysAdmin, SilikaAdmin")]
public class JenisWRController : Controller {
    private IJenisWrRepo repo;

    public JenisWRController(IJenisWrRepo jRepo) => repo = jRepo;

    [HttpGet("/wr/jenis")]
    public IActionResult Index() => View("~/Views/WR/Jenis/Index.cshtml");

    [HttpGet("/wr/jenis/create")]
    public IActionResult Create() => PartialView("~/Views/WR/Jenis/AddEdit.cshtml", new JenisWr());

    #nullable disable
    [HttpGet("/wr/jenis/edit")]
    public async Task<IActionResult> Edit(int jenisId) {
        JenisWr jns = await repo.JenisWrs.FirstOrDefaultAsync(j => j.JenisID == jenisId);
        return PartialView("~/Views/WR/Jenis/AddEdit.cshtml", jns);
    }

    [HttpPost("/wr/jenis/save")]
    public async Task<IActionResult> SaveDataAsync(JenisWr jenisWr) {
        if (ModelState.IsValid) {
            await repo.SaveDataAsync(jenisWr);
            return Json(Result.Success());
        }

        return PartialView("~/Views/WR/Jenis/AddEdit.cshtml", jenisWr);
    }
}