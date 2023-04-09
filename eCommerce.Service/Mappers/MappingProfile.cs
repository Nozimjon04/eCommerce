using AutoMapper;
using eCommerce.Domain.Entities;

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

	}
    

}
