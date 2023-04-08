using eCommerce.Domain.Commons;

namespace eCommerce.Domain.Entities.Carts
{
    public class CartProduct : Auditable
    {
        public long CartId { get; set; }
        public Cart Cart { get; set; } = default!;
        public long ProductId { get; set; }
        public Product Product { get; set; } = default!;
    }
}
