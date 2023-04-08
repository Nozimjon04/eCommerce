using eCommerce.Domain.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace eCommerce.Service.DTOs.Products
{
    public class ProductCommentCreationDto
    {
        [Required]
        [DisplayName("User Id")]
        public long UserId { get; set; }
        [Required]
        [DisplayName("Product Id")]

        public long ProductId { get; set; }
        [DisplayName("Comment")]

        public string Comment { get; set; } = string.Empty;
    }
}
