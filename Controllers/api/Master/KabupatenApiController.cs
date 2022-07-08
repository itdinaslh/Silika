using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Silika.Repository;
using System.Linq.Dynamic.Core;

namespace Silika.Controllers.api;

[ApiController]
[Route("[controller]")]
public class KabupatenApiController : Controller
{
    private IKabupatenRepo repo;

    public KabupatenApiController(IKabupatenRepo kRepo) => repo = kRepo;

    [HttpPost("/api/master/kabupaten")]
    public async Task<IActionResult> KabupatenTable()
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

        var init = repo.Kabupatens.Select(k => new
        {
            kabupatenID = k.KabupatenID,
            namaKabupaten = k.NamaKabupaten,
            namaProvinsi = k.Provinsi.NamaProvinsi,
            latitude = k.Latitude,
            longitude = k.Longitude
        });

        if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
        {
            init = init.OrderBy(sortColumn + " " + sortColumnDirection);
        }

        if (!string.IsNullOrEmpty(searchValue))
        {
            init = init.Where(a => a.namaKabupaten.ToLower().Contains(searchValue.ToLower()) ||
                a.namaProvinsi.ToLower().Contains(searchValue.ToLower())
            );
        }

        recordsTotal = init.Count();

        var result = await init.Skip(skip).Take(pageSize).ToListAsync();

        var jsonData = new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = result };

        return Ok(jsonData);
    }

    [HttpGet("/api/master/kabupaten/search")]
    public async Task<IActionResult> SearchKabupaten(string? term)
    {
        var data = await repo.Kabupatens
            .Where(a => a.ProvinsiID == "31")
            .Where(k => string.IsNullOrEmpty(term) || k.NamaKabupaten.ToLower().Contains(term.ToLower())
            ).Select(s => new
            {
                id = s.KabupatenID,
                namaKabupaten = s.NamaKabupaten
            }).Take(10).ToListAsync();

        return Ok(data);
    }
}