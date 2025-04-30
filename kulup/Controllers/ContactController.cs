

using Microsoft.AspNetCore.Mvc;

namespace kulup.Controllers;

public class ContactController : Controller
{


    public IActionResult Index()
    {
        return View();
    }
}