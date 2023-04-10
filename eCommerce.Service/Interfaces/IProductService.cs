using eCommerce.Domain.Entities;
using eCommerce.Service.DTOs.Products;
using System.Linq.Expressions;

namespace eCommerce.Service.Interfaces;

public interface IProductService
{
	public Task<productForResultDto> AddAsync(ProductCreationDto productCreationDto);
	public Task<productForResultDto> UpdateAsync(Expression<Func<Product, bool>> expression,ProductCreationDto dto);
	public Task<bool> DelateAsync(Expression<Func<Product, bool>> expression);
	public Task<productForResultDto> GetAsync(Expression<Func<Product,bool>> expression);
	public Task<IEnumerable<productForResultDto>> GetAllAsync();
}
