using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Silika.Entity;
using Silika.Repository;
using Silika.Helpers;
using Silika.Models;

namespace Silika.Controllers;

[Authorize(Roles = "SysAdmin, SilikaAdmin")]
public class MerkController : Controller {
    private IMerkKendaraan repo;

    public MerkController(IMerkKendaraan mRepo) {
        repo = mRepo;
    }

    [HttpGet("/transport/merk-kendaraan")]
    public IActionResult Index() => View("~/Views/Transport/Merk/Index.cshtml");

    
    [HttpGet("/transport/merk-kendaraan/create")]
    public IActionResult Create() => PartialView("~/Views/Transport/Merk/AddEdit.cshtml", new MerkKendaraan());

    [HttpGet("/transport/merk-kendaraan/edit")]
    public async Task<IActionResult> Edit(int merkID) => PartialView("~/Views/Transport/Merk/AddEdit.cshtml",
        await repo.MerkKendaraans.FirstOrDefaultAsync(m => m.MerkID == merkID)
    );

    [HttpPost("/transport/merk-kendaraan/save")]
    public async Task<IActionResult> SaveDataAsync(MerkKendaraan merk) {
        if (ModelState.IsValid) {
            await repo.SaveDataAsync(merk);
            return Json(Result.Success());
        }

        return PartialView("~/Views/Transport/Merk/AddEdit.cshtml", merk);
    }
}