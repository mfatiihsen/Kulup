


using kulup.Data;
using kulup.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace kulup.Controllers;

public class MemberController : Controller
{

    private readonly UygulamaDbContext _context;
    public MemberController(UygulamaDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var users = await _context.Members
            .Select(u => new Member
            {
                Id = u.Id,
                AdSoyad = u.AdSoyad,
                Email = u.Email,
                Telefon = u.Telefon.TrimStart('0'), // Telefon numarasındaki baştaki sıfırı kaldır
                Kulup = u.Kulup,
                CreatedAt = u.CreatedAt
            })
            .ToListAsync(); // Veritabanındaki kullanıcıları al

        return View(users); // Veriyi View'a gönder
    }


}