using AutoMapper;
using eCommerce.Data.IRepositories;
using eCommerce.Domain.Entities;
using eCommerce.Domain.Entities.Orders;
using eCommerce.Service.DTOs.Orders;
using eCommerce.Service.Interfaces;
using System.Linq.Expressions;

namespace eCommerce.Service.Services;

public class OrderItemService:IOrderItemService
{
	private readonly IRepository<OrderItem> orderItemRepository;
	private readonly IRepository<Order> orderRepository;
	private readonly IRepository<Product> productRepository;
	private readonly IMapper mapper;
	public OrderItemService(IRepository<OrderItem> orderItemRepo, IRepository<Order> orderRepository, IRepository<Product> productRepository,IMapper mapper)
	{
		this.orderItemRepository = orderItemRepo;
		this.orderRepository = orderRepository;
		this.productRepository = productRepository;
		this.mapper = mapper;
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
