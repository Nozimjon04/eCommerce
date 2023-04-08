using eCommerce.Domain.Entities.Carts;
using eCommerce.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace eCommerce.Service.DTOs.Charts
{
    public class ChartProductCreationDto
    {
        [Required]
        public long CartId { get; set; }
        [Required]
        public long ProductId { get; set; }
    }
}
