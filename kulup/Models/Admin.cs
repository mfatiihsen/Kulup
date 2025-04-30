

using System.ComponentModel.DataAnnotations;

namespace kulup.Models;

public class Admin
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Sicil Numarası boş bırakılamaz.")]
    public string sicilNo { get; set; }
    [Required]
    public string AdSoyad { get; set; }
    [EmailAddress]
    public string Email { get; set; }

    public string Telefon { get; set; } // ✅ Yeni eklenen alan

    public DateTime KayitTarihi { get; set; } // ✅ Yeni eklenen alan

    [Required(ErrorMessage = "Parola boş bırakılamaz.")]
    public string password { get; set; }
}