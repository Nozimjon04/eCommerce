using eCommerce.Domain.Entities;
using eCommerce.Domain.Enums;

namespace eCommerce.Service.DTOs.Order
{
    public class OrderForResultDto
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public OrderStatus Status { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
