

using System.ComponentModel.DataAnnotations;

namespace kulup.Models;

public class Admin
{
    public int Id {get;set;}

    [Required(ErrorMessage = "Sicil Numarası boş bırakılamaz.")]
    public string sicilNo {get;set;}

    [Required(ErrorMessage = "Parola boş bırakılamaz.")]
    public string password {get;set;}
}