using Microsoft.AspNetCore.Mvc;

namespace Silika.Controllers;

public class AccountController : Controller {
    [Route("/account/denied")]
    public IActionResult Denied() {
        return View();
    }
}