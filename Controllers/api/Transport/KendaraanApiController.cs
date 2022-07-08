using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

using Silika.Entity;
using Silika.Repository;

namespace Silika.Controllers.api;

[Route("api/[controller]")]
[ApiController]
public class KendaraanApiController : ControllerBase
{
    private readonly IKendaraan repo;

    public KendaraanApiController(IKendaraan repo)
    {
        this.repo = repo;
    }

    [HttpPost("/api/transport/kendaraan")]
    public async Task<IActionResult> PegawaiTable()
    {
        var draw = Request.Form["draw"].FirstOrDefault();
        var start = Request.Form["start"].FirstOrDefault();
        var length = Request.Form["length"].FirstOrDefault();
        var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
        var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
        var searchValue = Request.Form["search[value]"].FirstOrDefault();
        int pageSize = length != null ? Convert.ToInt32(length) : 0;
        int skip = start != null ? Convert.ToInt32(start) : 0;
        int recordsTotal = 0;

        var init = repo.Kendaraans.Select(x => new
        {
            kendaraanId = x.KendaraanId,
            noPolisi = x.NoPolisi,
            jenis = x.JenisKendaraan.NamaJenis,
            tahun = x.TahunPengadaan,
            bidang = x.BidangPenugasan!.NamaBidang,
            kabupaten = x.KabupatenPenugasan!.NamaKabupaten,
            kecamatan = x.KecamatanPenugasan!.NamaKecamatan
        });

        if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
        {
            init = init.OrderBy(sortColumn + " " + sortColumnDirection);
        }

        if (!string.IsNullOrEmpty(searchValue))
        {
            init = init.Where(a => a.noPolisi.ToLower().Contains(searchValue.ToLower()));
        }

        recordsTotal = init.Count();

        var result = await init.Skip(skip).Take(pageSize).ToListAsync();

        var jsonData = new { draw, recordsFiltered = recordsTotal, recordsTotal, data = result };

        return Ok(jsonData);
    }
}
