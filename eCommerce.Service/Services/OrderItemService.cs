using AutoMapper;
using eCommerce.Data.IRepositories;
using eCommerce.Domain.Entities;
using eCommerce.Domain.Entities.Orders;
using eCommerce.Service.DTOs.Orders;

using eCommerce.Service.Exceptions;
using eCommerce.Service.Interfaces;
using System.Linq.Expressions;

namespace eCommerce.Service.Services;

public class OrderItemService:IOrderItemService
{
	private readonly IRepository<OrderItem> OrderItemRepo;
	private readonly IMapper mapper;
	private readonly IOrderService orderService;
	private readonly IProductService productService;
	public OrderItemService(IRepository<OrderItem> orderItemRepo, IMapper mapper, IOrderService orderService, IProductService productService)
	{
		this.OrderItemRepo = orderItemRepo;
		this.mapper = mapper;
		this.orderService = orderService;
		this.productService = productService;
	}

	public async Task<Order> AddAsync(OrderItemCreationDto orderItemCreationDto)
	{
	
		
		throw new NotImplementedException();
	}

	public Task<bool> DelateAsync(Expression<Func<OrderItemCreationDto>> expression)
	{
		throw new NotImplementedException();
	}

	public Task<IEnumerable<Order>> GetAllAsync(Expression<Func<OrderItem>> expression)
	{
		throw new NotImplementedException();
	}

	public Task<Order> GetAsync(Expression<Func<OrderItemCreationDto>> expression)
	{
		throw new NotImplementedException();
	}

	public Task<Order> UpdateAsync(Expression<Func<OrderItemCreationDto, bool>> expression)
	{
		throw new NotImplementedException();
	}
}
