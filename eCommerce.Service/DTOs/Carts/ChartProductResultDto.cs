using eCommerce.Domain.Entities.Carts;
using eCommerce.Domain.Entities;

namespace eCommerce.Service.DTOs.Charts
{
    public class ChartProductResultDto
    {
        public long Id { get; set; }
        public long CartId { get; set; }
        public long ProductId { get; set; }
    }
}
