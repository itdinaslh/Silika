using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using Silika.Repository;

namespace Silika.Controllers.api;

[ApiController]
[Route("[controller]")]
// [Authorize(Roles = "SysAdmin")]
public class BidangApiController : Controller {
    private readonly IBidangRepo _repo;   

    public BidangApiController(IBidangRepo bRepo) {
        _repo = bRepo;        
    }

    [HttpPost("/api/master/bidang")]
    public async Task<IActionResult> BidangTable() {
        var draw = Request.Form["draw"].FirstOrDefault();
        var start = Request.Form["start"].FirstOrDefault();
        var length = Request.Form["length"].FirstOrDefault();
        var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
        var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
        var searchValue = Request.Form["search[value]"].FirstOrDefault();
        int pageSize = length != null ? Convert.ToInt32(length) : 0;
        int skip = start != null ? Convert.ToInt32(start) : 0;
        int recordsTotal = 0;

        var init = _repo.Bidangs;

        if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection))) {
            init = init.OrderBy(sortColumn + " " + sortColumnDirection);
        }

        if (!string.IsNullOrEmpty(searchValue)) {
            init = init.Where(a => a.NamaBidang.ToLower().Contains(searchValue.ToLower()) ||
                a.KepalaBidang!.ToLower().Contains(searchValue.ToLower())
            );
        }

        recordsTotal = init.Count();

        var result = await init.Skip(skip).Take(pageSize).ToListAsync();

        var jsonData = new { draw, recordsFiltered = recordsTotal, recordsTotal, data = result};
        
        return Ok(jsonData);
    }

    // [HttpGet("/api/master/bidang/spa")]
    // public async Task<IActionResult> Bidangs(int pageSize, string query, int currentPage = 1) {
    //     var start = repo.Bidangs
    //         .Where(b => !String.IsNullOrEmpty(query) ? 
    //             b.NamaBidang.ToLower().Contains(query.ToLower()) || b.KepalaBidang.ToLower().Contains(query.ToLower()) : true
    //         );

    //     var data = await start
    //         .Skip((currentPage - 1) * pageSize)
    //         .Take(pageSize)
    //         .OrderByDescending(b => b.BidangID)
    //         .ToListAsync();

    //     var bidangs = new BidangResponse(data, start.Count());

    //     return Ok(bidangs);
    // }

    // [HttpPut("/api/master/bidang/save")]
    // public async Task<IActionResult> SaveBidangApi(Bidang bidang) {
    //     if (ModelState.IsValid) {                      
    //         await repo.SaveBidangAsync(bidang);
    //         await _bidangHubContext.Clients.All.SendAsync("TableUpdated");
    //     } else {
    //         return BadRequest();
    //     }

    //     return Ok();
    // }

    
    [HttpGet("/api/master/bidang/getbyid")]
    public async Task<JsonResult> GetDataById(Guid bidangId) {
        var data = await _repo.Bidangs.Select(x => new {
            bidangID = x.BidangID,
            namaBidang = x.NamaBidang,
            kepalaBidang = x.KepalaBidang
        }).FirstOrDefaultAsync(b => b.bidangID == bidangId);

        return Json(data);
    }

    [HttpGet("/api/master/bidang/search")]
    public async Task<IActionResult> SearchBidang(string? term)
    {
        var data = await _repo.Bidangs
            .Where(k => !String.IsNullOrEmpty(term) ?
                k.NamaBidang.ToLower().Contains(term.ToLower()) : true
            ).Select(s => new {
                id = s.BidangID,
                namaBidang = s.NamaBidang
            }).Take(10).ToListAsync();

        return Ok(data);
    }
}