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
<<<<<<< HEAD
	public Task<IEnumerable<productForResultDto>> GetAllAsync();
=======
	public Task<IEnumerable<Product>> GetAllAsync(Expression<Func<Product,bool>> expression=null);
>>>>>>> 8eac051cc502ee52ec0bf15ce6223c99f0732ff5
}
