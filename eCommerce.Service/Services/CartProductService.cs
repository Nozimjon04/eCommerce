using AutoMapper;
using eCommerce.Data.DbContexts;
using eCommerce.Data.IRepositories;
using eCommerce.Domain.Entities.Carts;
using eCommerce.Service.DTOs.Charts;
using eCommerce.Service.Exceptions;
using eCommerce.Service.Interfaces;
using System.Linq.Expressions;

namespace eCommerce.Service.Services;

public class CartProductService : ICartProductService
{
    private readonly IRepository<CartProduct> cartProductRepository;
    private readonly AppDbContext appDbContext;
    private readonly IMapper mapper;
    public CartProductService(
        IRepository<CartProduct> cartProductRepository,
        AppDbContext appDbContext,
        IMapper mapper)
    {
        this.cartProductRepository = cartProductRepository;
        this.appDbContext = appDbContext;
        this.mapper = mapper;
    }

    public async Task<bool> AddAsync(CartProductCreationDto cartProductCreationDto)
    {
        var newcartproduct = await cartProductRepository.SelectAsync(cp => cp.CartId == cartProductCreationDto.CartId);

        if (newcartproduct is not null)
            throw new CustomException(400, "Already Exists");

        var mappedCartProduct = mapper.Map<CartProduct>(cartProductCreationDto);

        mappedCartProduct.CreatedAt = DateTime.UtcNow;

        await cartProductRepository.InsertAsync(mappedCartProduct);

        await cartProductRepository.SaveAsync();

        return true;
    }

    public async Task<bool> DelateAsync(Expression<Func<CartProduct, bool>> expression = null)
    {
        var cartProduct = await cartProductRepository.SelectAsync(expression);

        if (cartProduct is null)
            throw new CustomException(404, "Not found");

        await cartProductRepository.DeleteAsync(expression);

        await cartProductRepository.SaveAsync();

        return true;
    }

    public async Task<IEnumerable<CartProduct>> GetAllAsync(
        Expression<Func<CartProduct, bool>> expression = null)
        => cartProductRepository.SelectAllAsync();

    public async Task<CartProduct> GetAsync(Expression<Func<CartProduct, bool>> expression = null)
    {
        var cartProduct = await cartProductRepository.SelectAsync(expression);

        if (cartProduct is null)
            throw new CustomException(404, "User not exist");

        return cartProduct;
    }


    public async Task<bool> UpdateAsync(int id, CartProductResultDto cartProductResultDto)
    {
        var cart = await cartProductRepository.SelectAsync(o => o.Id == id);

        if (cart is null)
            throw new CustomException(404, "Not found");

        cart.UpdatedAt = DateTime.UtcNow;

        await cartProductRepository.UpdateAsync(cart);

        await cartProductRepository.SaveAsync();

        return true;
    }
}
