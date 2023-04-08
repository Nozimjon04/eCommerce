using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace eCommerce.Service.DTOs.Products;

public class ProductCreationDto
{
    [Required(ErrorMessage = "Please Enter Product name")]
    [DisplayName("Name")]

    public string Name { get; set; } = string.Empty;
    [Required(ErrorMessage = "Please Enter Price")]
    [DisplayName("Price")]

    public decimal Price { get; set; }
    [Required(ErrorMessage = "Please Enter Count")]
    [DisplayName("Count")]

    public int Count { get; set; }
    [Required(ErrorMessage = "Please Enter Description ")]
    [DisplayName("Description")]

    public string Description { get; set; } = string.Empty;
    [Required(ErrorMessage = "Please Enter SearchByTag")]
    [DisplayName("SearchByTag")]
    public string SearchByTag { get; set; } = string.Empty;
}
