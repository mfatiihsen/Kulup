

using kulup.Data;
using kulup.Models;
using Microsoft.AspNetCore.Mvc;

namespace kulup.Controllers
{
    public class RegisterController : Controller
    {

        private readonly UygulamaDbContext _context;
        public RegisterController(UygulamaDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(Member model)
        {
            if (ModelState.IsValid)
            {
                model.CreatedAt = DateTime.Now;
                // veri tabanına ekleme işlemi 
                _context.Members.Add(model);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }
    }
}