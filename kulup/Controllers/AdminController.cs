

using Microsoft.AspNetCore.Mvc;

namespace kulup.Controllers;

public class AdminController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Home(){
        return View("Home");
    }

    public IActionResult Message(){
        return View("Message");
    }

}