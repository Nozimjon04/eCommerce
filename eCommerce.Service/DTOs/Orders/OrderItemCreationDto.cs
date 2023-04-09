using eCommerce.Domain.Entities;
using eCommerce.Domain.Enums;

namespace eCommerce.Service.DTOs.Orders;

public class OrderItemCreationDto
{
	public bool isPaid { get; set; }=false;
	public long UserId { get; set; }
	public User User { get; set; } = default!;
	public OrderStatus Status { get; set; } = OrderStatus.Pending;
	public decimal TotalPrice { get; set; }
}
