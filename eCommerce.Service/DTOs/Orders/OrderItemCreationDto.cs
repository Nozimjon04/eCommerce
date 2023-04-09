using eCommerce.Domain.Entities;
using eCommerce.Domain.Enums;

namespace eCommerce.Service.DTOs.Orders;

public class OrderItemCreationDto
{
	public long OrderId { get; set; }
	public Order order { get; set; }
	public long ProductId { get; set; }
	public Product Product { get; set; }
	public int ProductCount { get; set; }
	public decimal ProductPrice { get; set; }
}
