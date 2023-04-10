using System.ComponentModel.DataAnnotations;

namespace eCommerce.Service.DTOs.Charts
{
    public class CartCreationDto
    {
        [Required]
        public long UserId { get; set; }

    }
}
