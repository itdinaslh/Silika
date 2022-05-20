using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
// using Silika.Entity;

namespace Silika.Controllers;

[Authorize]
public class BidangController : Controller {
    [HttpGet("/master/bidang")]
    public async Task<IActionResult> Index() {
        #nullable disable
        string token = await HttpContext.GetTokenAsync("access_token");
        return View("~/Views/Master/Bidang/Index.cshtml", token);
    }

    // [HttpGet("/master/bidang/create")]
    // public async Task<IActionResult> Create() {
    //     var accessToken = await HttpContext.GetTokenAsync("access_token");
    //     ViewBag.Token = accessToken;
    //     return PartialView("~/Views/Master/Bidang/AddEdit.cshtml", new Bidang { BidangID = Guid.Empty });
    // }
}