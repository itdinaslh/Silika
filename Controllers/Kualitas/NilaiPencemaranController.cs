using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Silika.Entity;
using Silika.Repository;
using Silika.Helpers;
using Silika.Models;

namespace Silika.Controllers;

[Authorize(Roles = "SysAdmin, SilikaAdmin")]
public class NilaiPencemaranController : Controller {
    private INilaiPencemaranRepo repo;

    public NilaiPencemaranController(INilaiPencemaranRepo nRepo) {
        repo = nRepo;
    }

    #nullable disable

    [HttpGet("/kualitas-lingkungan/nilai-pencemaran")]
    public IActionResult Index() => View("~/Views/Kualitas/NilaiPencemaran/Index.cshtml");

    [HttpGet("/kualitas-lingkungan/nilai-pencemaran/create")]
    public IActionResult Create() => PartialView("~/Views/Kualitas/NilaiPencemaran/AddEdit.cshtml", new NilaiPencemaran());

    [HttpGet("/kualitas-lingkungan/nilai-pencemaran/edit")]
    public async Task<IActionResult> Edit(int nilaiID) => PartialView("~/Views/Kualitas/NilaiPencemaran/AddEdit.cshtml",
        await repo.NilaiPencemarans.FirstOrDefaultAsync(n => n.NilaiID == nilaiID)
    );

    [HttpPost("/kualitas-lingkungan/nilai-pencemaran/save")]
    public async Task<IActionResult> SaveDataAsync(NilaiPencemaran nilai) {
        if (ModelState.IsValid) {
            await repo.SaveDataAsync(nilai);
            return Json(Result.Success());
        }

        return PartialView("~/Views/Kualitas/NilaiPencemaran/AddEdit.cshtml", nilai);
    }
}