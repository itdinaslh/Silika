using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Silika.Repository;
using Silika.Models;
using Silika.Entity;


namespace Silika.Controllers;

public class PegawaiController : Controller
{
    private readonly IPegawai repo;

    public PegawaiController(IPegawai repo)
    {
        this.repo = repo;
    }

    [HttpGet("/master/pegawai")]
    public IActionResult Index()
    {
        return View("~/Views/Master/Pegawai/Index.cshtml");
    }

}
