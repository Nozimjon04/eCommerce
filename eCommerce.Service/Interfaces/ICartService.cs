using eCommerce.Domain.Entities.Carts;
using eCommerce.Service.DTOs.Charts;
using System.Linq.Expressions;

namespace eCommerce.Service.Interfaces;

public interface ICartService
{
    Task<bool> AddAsync(CartCreationDto cartCreationDto);
    Task<bool> UpdateAsync(int id, CartForResultDto cartForResultDto);
    Task<bool> DelateAsync(Expression<Func<Cart, bool>> expression);
    Task<Cart> GetAsync(Expression<Func<Cart, bool>> expression = null!);
    Task<IEnumerable<Cart>> GetAllAsync(Expression<Func<Cart, bool>> expression = null!);
}
