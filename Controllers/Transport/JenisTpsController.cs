using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Silika.Entity;
using Silika.Repository;
using Silika.Helpers;
using Silika.Models;

namespace Silika.Controllers;

[Authorize(Roles = "SysAdmin, SilikaAdmin")]
public class JenisTpsController : Controller {
    private IJenisTpsRepo repo;

    public JenisTpsController(IJenisTpsRepo jnsTpsRepo) {
        repo = jnsTpsRepo;
    }

    [HttpGet("/transport/jenis-tps")]
    public IActionResult Index() => View("~/Views/Transport/JenisTps/Index.cshtml");

    [HttpGet("/transport/jenis-tps/create")]
    public IActionResult Create() => PartialView("~/Views/Transport/JenisTps/AddEdit.cshtml", new JenisTps());

    [HttpGet("/transport/jenis-tps/edit")]
    public async Task<IActionResult> Edit(int jenisID) => PartialView("~/Views/Transport/JenisTps/AddEdit.cshtml", 
        await repo.JenisTps.FirstOrDefaultAsync(j => j.JenisID == jenisID));

    #nullable disable
    [HttpPost("/transport/jenis-tps/save")]
    public async Task<IActionResult> SaveDataAsync(JenisTps jenis) {
        if (ModelState.IsValid) {
            await repo.SaveDataAsync(jenis);
            return Json(Result.Success());
        }

        return PartialView("~/Views/Transport/JenisTps/AddEdit.cshtml", jenis);
    }
}