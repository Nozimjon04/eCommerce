using AutoMapper;
using eCommerce.Data.IRepositories;
using eCommerce.Domain.Entities;
using eCommerce.Service.DTOs.Products;
using eCommerce.Service.Exceptions;
using eCommerce.Service.Interfaces;
using System.Linq.Expressions;

namespace eCommerce.Service.Services;

public class ProductService : IProductService
{
	private readonly IRepository<Product> productRepo;
	private readonly IMapper mapper;
	public ProductService(IRepository<Product> productRepo, IMapper mapper)
	{
		this.productRepo = productRepo;
		this.mapper = mapper;
	}

	public async Task<productForResultDto> AddAsync(ProductCreationDto productCreationDto)
	{
		var entity=await productRepo.SelectAsync(e=>e.Name.ToLower()==productCreationDto.Name.ToLower());
		if(entity is not null)
		{
			entity.Count += productCreationDto.Count;
			await productRepo.SaveAsync();
		}
		var result= this.mapper.Map<Product>(productCreationDto);
		result.CreatedAt = DateTime.UtcNow;
		await productRepo.InsertAsync(result);
		await productRepo.SaveAsync();
		
		return mapper.Map<productForResultDto>(result);
	}

	public async Task<bool> DelateAsync(Expression<Func<Product, bool>> expression)
	{
		
		var product = await productRepo.SelectAsync(p => p.Name.ToLower() == expression.Name.ToLower());
		if(product is null)
		{
			throw new CustomException(404, "Product is not found");
		}		
		await productRepo.DeleteAsync(expression);
		await productRepo.SaveAsync();
		return true;
	}

	public async Task<IEnumerable<Product>> GetAllAsync(Expression<Func<Product, bool>> expression=null)
	
		=> productRepo.SelectAllAsync();
		
	

	public async Task<productForResultDto> GetAsync(Expression<Func<Product, bool>> expression)
	{
		var entity=await productRepo.SelectAsync(expression);
		if(entity is null)
		{
			throw new CustomException(404, "Product is not found");
		}
		var result=mapper.Map<productForResultDto>(entity);
		return result;
		
	}

	public async Task<productForResultDto> UpdateAsync(Expression<Func<Product, bool>> expression,ProductCreationDto dto)
	{
		var entity = await productRepo.SelectAsync(expression);
		if(entity is null)
		{
			throw new CustomException(404, "product is not found");
		}
		var res = this.mapper.Map<Product>(dto);
		res.UpdatedAt= DateTime.UtcNow;
		await productRepo.UpdateAsync(res);
		await productRepo.SaveAsync();
		return mapper.Map<productForResultDto>(entity);
	}
}
