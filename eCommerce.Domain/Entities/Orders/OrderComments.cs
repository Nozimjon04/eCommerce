using eCommerce.Domain.Commons;

namespace eCommerce.Domain.Entities.Orders;

public class OrderComments : Auditable
{
    public long UserId { get; set; }
    public User User { get; set; } = default!;
    public long OrderId { get; set; }
    public Order Order { get; set; } = default!;

    // To leave Comment
    public string Comment { get; set; } = string.Empty;
}
