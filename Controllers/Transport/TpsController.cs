using Microsoft.AspNetCore.Mvc;
using Silika.Entity;
using Silika.Models;
using Silika.Helpers;
using Silika.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace Silika.Controllers;

[Authorize]
public class TpsController : Controller
{
    private readonly ITps repo;

    public TpsController(ITps tRepo) => repo = tRepo;

    [HttpGet("/transport/tps")]
    public IActionResult Index()
    {
        return View("~/Views/Transport/Tps/Index.cshtml");
    }

    [HttpGet("/transport/tps/create")]
    public IActionResult Create() {
        return PartialView("~/Views/Transport/Tps/AddEdit.cshtml", new TpsViewModel {
            Tps = new Tps()
        });
    }

    [HttpGet("/transport/tps/map")]
    public IActionResult Map() {
        return View("~/Views/Transport/Tps/Map.cshtml");
    }

    [HttpGet("/transport/tps/edit")]
    public async Task<IActionResult> Edit(int id) {
        var data = await repo.Tps
            .Select(x => new {
                x.TpsId, x.TpsCode, x.NamaTps, x.JenisTpsId, x.KelurahanID, x.KodePos, x.Keterangan,
                x.Latitude, x.Longitude, x.Alamat, x.StatusLahanId, 
                x.JenisTps.NamaJenis,
                x.Kelurahan.Kecamatan.Kabupaten.KabupatenID, x.Kelurahan.Kecamatan.Kabupaten.NamaKabupaten,
                x.Kelurahan.KecamatanID, x.Kelurahan.Kecamatan.NamaKecamatan,
                x.Kelurahan.NamaKelurahan,
                x.StatusLahan.NamaStatus
            })
            .FirstOrDefaultAsync(t => t.TpsId == id);

        if (data is not null) {
            return PartialView("~/Views/Transport/Tps/AddEdit.cshtml", new TpsViewModel {
                Tps = new Tps {
                    TpsId = data.TpsId, TpsCode = data.TpsCode, NamaTps = data.NamaTps, JenisTpsId = data.JenisTpsId,
                    KelurahanID = data.KelurahanID, KodePos = data.KodePos, Keterangan = data.Keterangan, Latitude = data.Latitude,
                    Longitude = data.Longitude, Alamat = data.Alamat, StatusLahanId = data.StatusLahanId
                },

                KotaID = data.KabupatenID,
                KecamatanID = data.KecamatanID,
                NamaKota = data.NamaKabupaten,
                NamaKecamatan = data.NamaKecamatan,
                JenisTps = data.NamaJenis,
                NamaKelurahan = data.NamaKelurahan,
                StatusLahan = data.NamaStatus
            });
        }

        return NotFound();
    }

    [HttpPost("/transport/tps/store")]
    public async Task<IActionResult> SaveDataAsync(TpsViewModel model) {
        if (ModelState.IsValid) {
            await repo.SaveDataAsync(model.Tps);

            return Json(Result.Success());
        }

        return PartialView("~/Views/Transport/Tps/AddEdit.cshtml", model);
    }
}
