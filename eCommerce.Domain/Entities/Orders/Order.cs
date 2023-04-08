using eCommerce.Domain.Commons;
using eCommerce.Domain.Enums;

namespace eCommerce.Domain.Entities
{
    public class Order : Auditable
    {
        public long UserId { get; set; }
        public User User { get; set; } = default!;
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        public decimal TotalPrice { get; set; }
    }
}
