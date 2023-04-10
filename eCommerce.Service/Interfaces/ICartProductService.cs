using eCommerce.Domain.Entities.Carts;
using eCommerce.Service.DTOs.Charts;
using System.Linq.Expressions;

namespace eCommerce.Service.Interfaces;

public interface ICartProductService
{
    Task<bool> AddAsync(CartProductCreationDto cartCreationDto);
    Task<bool> UpdateAsync(int id, CartProductResultDto cartProductResultDto);
    Task<bool> DelateAsync(Expression<Func<CartProduct, bool>> expression = null!);
    Task<CartProduct> GetAsync(Expression<Func<CartProduct, bool>> expression = null!);
    Task<IEnumerable<CartProduct>> GetAllAsync(Expression<Func<CartProduct, bool>> expression = null!);
}
