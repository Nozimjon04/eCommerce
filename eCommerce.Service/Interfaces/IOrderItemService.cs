using eCommerce.Domain.Entities;
using eCommerce.Domain.Entities.Orders;
using eCommerce.Service.DTOs.Orders;
using System.Linq.Expressions;

namespace eCommerce.Service.Interfaces;

public interface IOrderItemService
{
	public Task<Order> AddAsync(OrderItemCreationDto orderItemCreationDto);
	public Task<Order> UpdateAsync(Expression<Func<OrderItemCreationDto, bool>> expression);
	public Task<bool> DelateAsync(Expression<Func<OrderItemCreationDto>> expression);
	public Task<Order> GetAsync(Expression<Func<OrderItemCreationDto>> expression);
	public Task<IEnumerable<Order>> GetAllAsync(Expression<Func<OrderItem>> expression);
}
