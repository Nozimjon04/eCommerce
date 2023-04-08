using eCommerce.Service.DTOs.Charts;
using System.Linq.Expressions;

namespace eCommerce.Service.Interfaces;

public interface ICartProductService
{
	public Task<CartForResultDto> AddAsync(CartCreationDto cartCreationDto);
	public Task<CartForResultDto> UpdateAsync(Expression<Func<CartCreationDto, bool>> expression);
	public Task<bool> DelateAsync(Expression<Func<CartCreationDto, bool>> expression);
	public Task<CartForResultDto> GetAsync(Expression<Func<CartProductCreationDto, bool>> expression);
	public Task<IEnumerable<CartForResultDto>> GetAllAsync();
}
