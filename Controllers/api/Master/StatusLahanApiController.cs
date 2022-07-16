using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using Silika.Repository;

namespace Silika.Controllers.api;

[Route("api/[controller]")]
[ApiController]
public class StatusLahanApiController : ControllerBase
{
    private readonly IStatusLahan repo;

    public StatusLahanApiController(IStatusLahan repo)
    {
        this.repo = repo;
    }

    [HttpPost("/api/master/status-lahan")]
    public async Task<IActionResult> BidangTable()
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

        var init = repo.StatusLahans;

        if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
        {
            init = init.OrderBy(sortColumn + " " + sortColumnDirection);
        }

        if (!string.IsNullOrEmpty(searchValue))
        {
            init = init.Where(a => a.NamaStatus.ToLower().Contains(searchValue.ToLower()));
        }

        recordsTotal = init.Count();

        var result = await init.Skip(skip).Take(pageSize).ToListAsync();

        var jsonData = new { draw, recordsFiltered = recordsTotal, recordsTotal, data = result };

        return Ok(jsonData);
    }

    [HttpGet("/api/master/status-lahan/search")]
    public async Task<IActionResult> SearchMerk(string? term)
    {
        var data = await repo.StatusLahans
            .Where(k => !String.IsNullOrEmpty(term) ?
                k.NamaStatus.ToLower().Contains(term.ToLower()) : true
            ).Select(s => new {
                id = s.StatusLahanId,
                namaStatus = s.NamaStatus
            }).Take(10).ToListAsync();

        return Ok(data);
    }
}
