using eCommerce.Domain.Commons;

namespace eCommerce.Domain.Entities
{
    public class Payment : Auditable
    {
        public long UserId { get; set; }
        public User User { get; set; } = default!;
        public decimal Price { get; set; }
        public long OrderId { get; set; }
        public Order Order { get; set; } = default!;
    }
}
