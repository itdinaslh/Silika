using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

using Silika.Entity;
using Silika.Repository;

namespace Silika.Controllers.api;

[ApiController]
[Route("[controller]")]
public class JenisWrApiController : Controller {
    private IJenisWrRepo repo;

    public JenisWrApiController(IJenisWrRepo jRepo) => repo = jRepo;

    [HttpPost("/api/wr/jenis")]
    public async Task<IActionResult> JenisTable() {
        var draw = Request.Form["draw"].FirstOrDefault();
        var start = Request.Form["start"].FirstOrDefault();
        var length = Request.Form["length"].FirstOrDefault();
        var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
        var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
        var searchValue = Request.Form["search[value]"].FirstOrDefault();
        int pageSize = length != null ? Convert.ToInt32(length) : 0;
        int skip = start != null ? Convert.ToInt32(start) : 0;
        int recordsTotal = 0;

        var init = repo.JenisWrs;

        if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection))) {
            init = init.OrderBy(sortColumn + " " + sortColumnDirection);
        }

        if (!string.IsNullOrEmpty(searchValue)) {
            init = init.Where(a => a.NamaJenis.ToLower().Contains(searchValue.ToLower()) ||
                a.NoRekening.ToLower().Contains(searchValue.ToLower())
            );
        }

        recordsTotal = init.Count();

        var result = await init.Skip(skip).Take(pageSize).ToListAsync();

        var jsonData = new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = result};
        
        return Ok(jsonData);
    }
}