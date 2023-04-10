using AutoMapper;
using eCommerce.Data.IRepositories;
using eCommerce.Domain.Entities;
using eCommerce.Domain.Entities.Orders;
using eCommerce.Service.DTOs.Orders;
using eCommerce.Service.Exceptions;
using eCommerce.Service.Interfaces;
using System.Linq.Expressions;


namespace eCommerce.Service.Services;

public class OrderItemService: IOrderItemService
{
	private readonly IRepository<OrderItem> repository;
	private readonly IOrderService orderService;
	private readonly IProductService productService;
	private readonly IMapper mapper;

	public OrderItemService(IRepository<OrderItem> repository,
			IMapper mapper,
			IOrderService orderService,
			IProductService productService)
		{
			this.repository = repository;
			this.mapper = mapper;
			this.orderService = orderService;
			this.productService = productService;
		}

	public async Task<OrderItem> AddAsync(OrderItemCreationDto dto)
	{
		var order = await this.orderService.GetAsync(order => order.Id == dto.OrderId);
		var product = await this.productService.GetAsync(product => product.Id == dto.ProductId);

		if (order is null || product is null)
		{
			throw new CustomException(400, "No matching Product or Order	");
		}
		else if (order is not null && product is not null)
		{
			var result=this.mapper.Map<OrderItem>(dto);
			result.CreatedAt = DateTime.UtcNow;
			await this.repository.InsertAsync(result);
			await this.repository.SaveAsync();
			return result;

		}
		throw new CustomException(500, "something went wrong");
    }

    public async Task<bool> DelateAsync(Expression<Func<OrderItem,bool>> expression)
	{
		var isDeleted = await this.repository.DeleteAsync(expression);
		if (isDeleted is false)
            throw new CustomException(400, "No Matching ");

		await this.repository.SaveAsync();

		return isDeleted;
    }

    public async Task<IEnumerable<OrderItem>> GetAllAsync()
	{
		var items =  this.repository.SelectAllAsync();
		if (items is null)
			throw new CustomException(404, "Items not found");

		var mappedItem = this.mapper.Map<IEnumerable<OrderItem>>(items);
		return mappedItem;
	}

	public async Task<OrderItem> GetAsync(Expression<Func<OrderItem,bool>> expression)
	{
		var item = await this.repository.SelectAsync(expression);
		if(item is null)
            throw new CustomException(404, "Item not found");


		var result = this.mapper.Map<OrderItem>(item);
		return result;
    }

	public async Task<OrderItem> UpdateAsync(Expression<Func<OrderItem, bool>> expression, OrderItemCreationDto dto)
	{
		var selected = await this.repository.SelectAsync(expression);
		if (selected is null)
            throw new CustomException(404, "Item not found");

		try
		{
			var result = this.mapper.Map<OrderItem>(selected);
			result.UpdatedAt = DateTime.UtcNow;
			var res = await this.repository.UpdateAsync(result);
			await this.repository.SaveAsync();
			return res;
		}
		catch 
		{
            throw new CustomException(500, "Something went wrong");
        }
    }


}
