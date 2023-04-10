using AutoMapper;
using eCommerce.Domain.Entities;
using eCommerce.Domain.Entities.Orders;
using eCommerce.Service.DTOs.Orders;
using eCommerce.Service.DTOs.Products;
using eCommerce.Service.DTOs.Users;


namespace eCommerce.Service.Mappers;

public class MappingProfile:Profile
{
	public MappingProfile()
	{

		CreateMap<Product, ProductCreationDto>().ReverseMap();
		CreateMap<productForResultDto,Product>().ReverseMap();
		CreateMap<IEnumerable<Product>, productForResultDto>().ReverseMap();
        CreateMap<UserCreationDto, User>().ReverseMap();
		CreateMap<User, UserForResultDto>().ReverseMap();
		CreateMap<Order,OrderCreationDto>().ReverseMap();
		CreateMap<OrderItem, OrderItemCreationDto>().ReverseMap();

	}
    

}
