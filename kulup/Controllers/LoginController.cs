


using kulup.Data;
using kulup.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace kulup.Controllers;


public class LoginController : Controller
{
    private readonly UygulamaDbContext _context;
    public LoginController(UygulamaDbContext context)
    {
        _context = context;
    }

    // GET:Login
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginModel model)
    {
        if (ModelState.IsValid)
        {
            var user = await _context.Members.FirstOrDefaultAsync(u => u.Email == model.Email && u.Sifre == model.Password);
            if (user !=null)
            {
                return RedirectToAction("Home","Index");
            }

            ModelState.AddModelError(string.Empty, "Kullanıcı adı veya şifre hatalı.");
        }
        return View("Index", model);
    }

}