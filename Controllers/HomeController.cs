﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Silika.Models;
using Microsoft.AspNetCore.Authorization;


namespace Silika.Controllers;

[Authorize]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet("/")]    
    public IActionResult Index()
    {
        var claimsIdentity = User.Identity;
        ViewBag.Claims = claimsIdentity;

        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
