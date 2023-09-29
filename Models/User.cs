using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Models;

[Table("User", Schema ="EcommerceTask")]

public class User
{
    [Key]
    [Display(Name ="ID")]
    public int Id { get; set; }

    [Required(ErrorMessage = "Username is required.")]
    [Display(Name ="User Name")]
    [Column(TypeName = "varchar(250)")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 100 characters.")]
    public string? Username { get; set; }

    [Required(ErrorMessage = "Password is required.")]
    [Display(Name ="Password")]
    [Column(TypeName = "varchar(250)")]
    [StringLength(255, MinimumLength = 6, ErrorMessage = "Password must be between 6 and 255 characters.")]
    [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&*()_+])(?!.*\s).*$", ErrorMessage = "Password must contain at least one uppercase letter, one lowercase letter, one digit, and one special character.")]
    public string? Password { get; set; }
}