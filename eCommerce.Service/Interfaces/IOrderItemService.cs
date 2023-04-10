using eCommerce.Domain.Entities;
using eCommerce.Domain.Entities.Orders;
using eCommerce.Service.DTOs.Orders;
using System.Linq.Expressions;

namespace eCommerce.Service.Interfaces;

public interface IOrderItemService
{
	public Task<OrderItem> AddAsync(OrderItemCreationDto orderItemCreationDto);
	public Task<OrderItem> UpdateAsync(Expression<Func<OrderItem, bool>> expression, OrderItemCreationDto orderItemCreationDto);
	public Task<bool> DelateAsync(Expression<Func<OrderItem, bool>> expression);
	public Task<OrderItem> GetAsync(Expression<Func<OrderItem,bool>> expression);
	public Task<IEnumerable<OrderItem>> GetAllAsync();
}
