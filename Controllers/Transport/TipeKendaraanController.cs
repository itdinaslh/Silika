using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Silika.Models;
using Silika.Repository;
using Silika.Entity;
using Silika.Helpers;

namespace Silika.Controllers;

public class TipeKendaraanController : Controller
{
    public readonly ITipeKendaraan repo;

    public TipeKendaraanController(ITipeKendaraan repo)
    {
        this.repo = repo;
    }

    [HttpGet("/transport/tipe-kendaraan")]
    public IActionResult Index()
    {
        return View("~/Views/Transport/TipeKendaraan/Index.cshtml");
    }

    [HttpGet("/transport/tipe-kendaraan/create")]
    public IActionResult Create()
    {
        return PartialView("~/Views/Transport/TipeKendaraan/AddEdit.cshtml", new TipeKendaraanVM());
    }

#nullable disable

    [HttpGet("/transport/tipe-kendaraan/edit")]
    public async Task<IActionResult> Edit(int id)
    {
        TipeKendaraan tipe = await repo.TipeKendaraans.FirstOrDefaultAsync(t => t.TipeKendaraanId == id);

        return PartialView("~/Views/Transport/TipeKendaraan/AddEdit.cshtml", new TipeKendaraanVM
        {
            TipeKendaraan = tipe
        });
    }

    [HttpPost("/transport/tipe-kendaraan/save")]
    public async Task<IActionResult> SaveDataAsync(TipeKendaraanVM vm)
    {
        if (ModelState.IsValid)
        {
            await repo.SaveDataAsync(vm.TipeKendaraan);

            return Json(Result.Success());
        }

        return PartialView("~/Views/Transport/TipeKendaraan/AddEdit.cshtml", vm);
    }
}
