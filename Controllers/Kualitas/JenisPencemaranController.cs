using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Silika.Entity;
using Silika.Repository;
using Silika.Helpers;
using Silika.Models;

namespace Silika.Controllers;

[Authorize(Roles = "SysAdmin, SilikaAdmin")]
public class JenisPencemaranController : Controller {
    private IJenisPencemaranRepo repo;

    public JenisPencemaranController(IJenisPencemaranRepo jRepo) {
        repo = jRepo;
    }

    [HttpGet("/kualitas-lingkungan/jenis-pencemaran")]
    public IActionResult Index() => View("~/Views/Kualitas/JenisPencemaran/Index.cshtml");

    [HttpGet("/kualitas-lingkungan/jenis-pencemaran/create")]
    public IActionResult Create() => PartialView("~/Views/Kualitas/JenisPencemaran/AddEdit.cshtml", new JenisPencemaran());

    [HttpGet("/kualitas-lingkungan/jenis-pencemaran/edit")]
    public async Task<IActionResult> Edit(int jenisID) => PartialView("~/Views/Kualitas/JenisPencemaran/AddEdit.cshtml", 
        await repo.JenisPencemarans.FirstOrDefaultAsync(j => j.JenisID == jenisID)
    );

    [HttpPost("/kualitas-lingkungan/jenis-pencemaran/save")]
    public async Task<IActionResult> SaveDataAsync(JenisPencemaran jenis) {
        if (ModelState.IsValid) {
            await repo.SaveDataAsync(jenis);
            return Json(Result.Success());
        }

        return PartialView("~/Views/Kualitas/JenisPencemaran/AddEdit.cshtml", jenis);
    }
}