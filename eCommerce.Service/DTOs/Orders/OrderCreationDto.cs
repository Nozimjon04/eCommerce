using eCommerce.Domain.Entities;
using eCommerce.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace eCommerce.Service.DTOs.Order
{
    public class OrderCreationDto
    {
        [Required]
        public long UserId { get; set; }
        public bool isPaid { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        [Required]
        public decimal TotalPrice { get; set; }

    }
}
