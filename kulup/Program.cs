using System.Net;
using System.Net.Mail;
using kulup.Data;
using kulup.Service;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// veri tabanı konfirgürasyonu
builder.Services.AddDbContext<UygulamaDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// SMTP ayarları
builder.Services.AddSingleton<IEmailSender,EmailSender>();
builder.Services.AddSingleton<SmtpClient>(sp =>
{
    var smtpClient = new SmtpClient("smtp.mailtrap.io")
    {
        Credentials = new NetworkCredential("ademfatih37@gmail.com", "password"),
        Port = 587,
    };

    return smtpClient;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
