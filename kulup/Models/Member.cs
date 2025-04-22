

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kulup.Models;

public class Member
{


     public int Id { get; set; }

    [Required]
    public string AdSoyad { get; set; }

    [Required, EmailAddress]
    public string Email { get; set; }

    [Required]
    public string Telefon { get; set; }

    [Required]
    public string Sifre { get; set; }

    // NotMapped yazmamızın sebebi bu property'nin veritabanında bir karşılığı olmaması.
    // Bu property sadece model üzerinde çalışacak ve veritabanına kaydedilmeyecek.
    [NotMapped]
    [Compare("Sifre", ErrorMessage = "Şifreler uyuşmuyor.")]
    public string SifreTekrar { get; set; }

    public string Kulup { get; set; }
    public DateTime CreatedAt { get; set; } // Kayıt tarihi
}