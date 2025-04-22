

using kulup.Data;
using kulup.Models;
using kulup.Service;
using Microsoft.AspNetCore.Mvc;

namespace kulup.Controllers;

public class ContactController : Controller
{
    private readonly UygulamaDbContext _context;
    private readonly EmailSender _emailSender;


    public ContactController(UygulamaDbContext context, EmailSender emailSender)
    {
        _context = context;
        _emailSender = emailSender;
    }
    public IActionResult Index()
    {
        return View();
    }


    [HttpPost]
    public async Task<IActionResult> SendMessage(string Name, string Email, string MessageContent,string Subject)
    {
        // Veritabanına mesaj kaydet
        var message = new Message
        {
            Name = Name,
            Email = Email,
            Subject = Subject,
            MessageContent = MessageContent,
            CreatedAt = DateTime.Now
        };
        _context.Messages.Add(message);
        await _context.SaveChangesAsync();

        // Admin'e e-posta gönder
        var subject = "Yeni İletişim Formu Mesajı";
        var body = $"Ad Soyad: {Name}\nE-posta: {Email}\n\nMesaj:\n{MessageContent}";
        await _emailSender.SendEmailAsync("ademfatih37@gmail.com", subject, body);

        return RedirectToAction("Index", "Home");
    }

}