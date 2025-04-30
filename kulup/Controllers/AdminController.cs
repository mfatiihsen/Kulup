

using Microsoft.AspNetCore.Mvc;
using kulup.Data;
using Microsoft.AspNetCore.Authorization;
using kulup.Models;
using Microsoft.EntityFrameworkCore;

namespace kulup.Controllers;

public class AdminController : Controller
{

    private readonly UygulamaDbContext _context;
    public AdminController(UygulamaDbContext context)
    {
        _context = context;
    }

    public IActionResult Home()
    {
        return View("Home");
    }


    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(string sicilNo, string password)
    {
        var admin = _context.Admins.FirstOrDefault(a => a.sicilNo == sicilNo && a.password == password);

        if (admin != null)
        {
            HttpContext.Session.SetString("AdminId", admin.Id.ToString());
            return RedirectToAction("Home", "Admin");
        }
        else
        {
            ViewBag.ErrorMessage = "Sicil Numarası veya Parola hatalı.";
            return View();
        }
    }

    public async Task<IActionResult> Members()
    {
        var users = await _context.Members.Select(u => new Member
        {
            Id = u.Id,
            AdSoyad = u.AdSoyad,
            Email = u.Email,
            Telefon = u.Telefon.TrimStart('0'), // Telefon numarasındaki baştaki sıfırı kaldır
            Kulup = u.Kulup,
            CreatedAt = u.CreatedAt
        }).ToListAsync(); // Veritabanındaki kullanıcıları al

        return View(users); // Veriyi View'a gönder
    }

    // Kullanıcıyı silmek için Delete metodu
    [HttpPost]
    [ActionName("DeleteConfirmed")] 
    public IActionResult DeleteConfirmed(int id)
    {
        var member = _context.Members.FirstOrDefault(m => m.Id == id);

        if (member == null)
        {
            return NotFound(); 
        }

        _context.Members.Remove(member); 
        _context.SaveChanges();  

        return RedirectToAction(nameof(Members));  // Silme işlemi başarılı, kullanıcılar sayfasına yönlendirme
    }


    public IActionResult Message()
    {
        return View("Message");
    }

}