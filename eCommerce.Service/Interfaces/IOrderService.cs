using eCommerce.Domain.Entities;
using eCommerce.Service.DTOs.Order;
using System.Linq.Expressions;

namespace eCommerce.Service.Interfaces;

public interface IOrderService
{
	public Task<OrderForResultDto> AddAsync(OrderCreationDto orderCreationDto);
	public Task<OrderForResultDto> UpdateAsync(Expression<Func<Order, bool>> expression, OrderForResultDto orderForResultDto);
	public Task<bool> DelateAsync (Expression<Func<Order, bool>> expression);
	public Task<OrderForResultDto> GetAsync(Expression<Func<Order, bool>> expression);
	public Task<IEnumerable<OrderForResultDto>> GetAllAsync();

}
