using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Silika.Entity;
using Silika.Repository;
using Silika.Helpers;
using Silika.Models;

namespace Silika.Controllers;

[Authorize(Roles = "SysAdmin, SilikaAdmin")]
public class JenisKendaraanController : Controller {
    private readonly IJenisKendaraanRepo repo;

    public JenisKendaraanController(IJenisKendaraanRepo jenisRepo) {
        repo = jenisRepo;
    }

    [HttpGet("/transport/jenis-kendaraan")]
    public IActionResult Index() => View("~/Views/Transport/JenisKendaraan/Index.cshtml");

    [HttpGet("/transport/jenis-kendaraan/create")]
    public IActionResult Create() => PartialView("~/Views/Transport/JenisKendaraan/AddEdit.cshtml", new JenisKendaraan());

    #nullable disable
    [HttpGet("/transport/jenis-kendaraan/edit")]
    public async Task<IActionResult> Edit(int jenisID) {
        JenisKendaraan jns = await repo.JenisKendaraans.FirstOrDefaultAsync(j => j.JenisID == jenisID);

        return PartialView("~/Views/Transport/JenisKendaraan/AddEdit.cshtml", jns);
    }

    [HttpPost("/transport/jenis-kendaraan/save")]
    public async Task<IActionResult> SaveDataAsync(JenisKendaraan jnsKendaraan) {
        if (ModelState.IsValid) {
            await repo.SaveDataAsync(jnsKendaraan);
            return Json(Result.Success());
        }

        return PartialView("~/Views/Transport/JenisKendaraan/AddEdit.cshtml", jnsKendaraan);
    }
}