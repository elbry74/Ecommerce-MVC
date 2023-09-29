using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Models;

[Table("Product", Schema ="EcommerceTask")]
public class Product
{
    [Key]
    [Display(Name ="ID")]
    public int Id { get; set; }

    [Required(ErrorMessage = "Product Name is required.")]
    [Display(Name ="Product Name")]
    [Column(TypeName = "varchar(250)")]
    [MaxLength(100, ErrorMessage = "Product Name cannot exceed 100 characters.")]
    [MinLength(2, ErrorMessage = "Product Name must be at least 2 characters.")]
    public string? ProductName { get; set; }

    [Display(Name ="Image Url")]
    [Column(TypeName = "varchar(250)")]
    public string? ImageUrl { get; set; }

    [Required(ErrorMessage = "Brand is required.")]
    [Display(Name ="Brand")]
    [Column(TypeName = "varchar(250)")]
    [MaxLength(50, ErrorMessage = "Brand cannot exceed 50 characters.")]
    [MinLength(2, ErrorMessage = "Brand must be at least 2 characters.")]
    public string? Brand { get; set; }

    [Required(ErrorMessage = "Type is required.")]
    [Display(Name ="Type")]
    [Column(TypeName = "varchar(250)")]
    [MaxLength(50, ErrorMessage = "Type cannot exceed 50 characters.")]
    [MinLength(2, ErrorMessage = "Type must be at least 2 characters.")]
    public string? Type { get; set; }

    [Required(ErrorMessage = "Description is required.")]
    [Display(Name ="Description")]
    [Column(TypeName = "varchar(250)")]
    [MaxLength(1000, ErrorMessage = "Description cannot exceed 1000 characters.")]
    [MinLength(10, ErrorMessage = "Description must be at least 10 characters.")]
    public string? Description { get; set; }
}
