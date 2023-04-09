using eCommerce.Service.DTOs.Orders;
using System.Linq.Expressions;

namespace eCommerce.Service.Interfaces;

public interface IOrderService
{
	public Task<OrderForResultDto> AddAsync(OrderCreationDto orderCreationDto);
	public Task<OrderForResultDto> UpdateAsync(OrderForResultDto orderForResultDto);
	public Task<bool> DelateAsync (Expression<Func<OrderCreationDto, bool>> expression);
	public Task<OrderForResultDto> GetAsync(Expression<Func<OrderCreationDto, bool>> expression);
	public Task<IEnumerable<OrderForResultDto>> GetAllAsync();

}
