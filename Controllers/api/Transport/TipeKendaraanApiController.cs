﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Linq.Dynamic.Core;

using Silika.Entity;
using Silika.Repository;

namespace Silika.Controllers.api;

[Route("api/[controller]")]
[ApiController]

public class TipeKendaraanApiController : ControllerBase
{
    private readonly ITipeKendaraan repo;

    public TipeKendaraanApiController(ITipeKendaraan repo)
    {
        this.repo = repo;
    }


    [HttpPost("/api/transport/tipe-kendaraan")]
    public async Task<IActionResult> JenisTable()
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

        var init = repo.TipeKendaraans.Select(x => new {
            tipeKendaraanId = x.TipeKendaraanId,            
            namaMerk = x.MerkKendaraan!.NamaMerk,
            namaTipe = x.NamaTipe
        });

        if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
        {
            init = init.OrderBy(sortColumn + " " + sortColumnDirection);
        }

        if (!string.IsNullOrEmpty(searchValue))
        {
            init = init.Where(a => a.namaTipe.ToLower().Contains(searchValue.ToLower()) ||
                a.namaMerk.ToLower().Contains(searchValue.ToLower())
            );
        }

        recordsTotal = init.Count();

        var result = await init.Skip(skip).Take(pageSize).ToListAsync();

        var jsonData = new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = result };

        return Ok(jsonData);
    }

    [HttpGet("/api/transport/tipe/search")]
    public async Task<IActionResult> SearchMerk(string? term)
    {
        var data = await repo.TipeKendaraans
            .Where(k => !String.IsNullOrEmpty(term) ?
                k.NamaTipe.ToLower().Contains(term.ToLower()) : true
            ).Select(s => new {
                id = s.TipeKendaraanId,
                namaTipe = s.NamaTipe
            }).Take(10).ToListAsync();

        return Ok(data);
    }
}
