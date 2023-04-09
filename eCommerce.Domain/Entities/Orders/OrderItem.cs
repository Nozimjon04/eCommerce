using eCommerce.Domain.Commons;

namespace eCommerce.Domain.Entities.Orders;

public class OrderItem:Auditable
{
	public long OrderId { get; set; }
 	public Order Order { get; set; }
	public long ProductId { get; set; }
	public Product Product { get; set; }
	public int ProductCount { get; set; }
	public decimal ProductPrice { get; set; }

}
