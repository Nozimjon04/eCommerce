using System.ComponentModel.DataAnnotations;

namespace eCommerce.Service.DTOs.Charts
{
    public class ChartCreationDto
    {
        [Required]
        public long UserId { get; set; }

    }
}
