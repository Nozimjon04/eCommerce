using eCommerce.Domain.Commons;

namespace eCommerce.Domain.Entities.Carts;

public class Cart : Auditable
{
    public long UserId { get; set; }
    public User User { get; set; } = default!;

}
