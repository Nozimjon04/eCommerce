using AutoMapper;
using eCommerce.Data.DbContexts;
using eCommerce.Data.IRepositories;
using eCommerce.Domain.Entities.Carts;
using eCommerce.Service.DTOs.Charts;
using eCommerce.Service.Exceptions;
using eCommerce.Service.Interfaces;
using System.Linq.Expressions;

namespace eCommerce.Service.Services;

public class CartService : ICartService
{
    private readonly IRepository<Cart> cartRepository;
    private readonly AppDbContext appDbContext;
    private readonly IMapper mapper;

    public CartService(
        IRepository<Cart> cartRepository,
        AppDbContext appDbContext,
        IMapper mapper)
    {
        this.cartRepository = cartRepository;
        this.appDbContext = appDbContext;
        this.mapper = mapper;
    }

    public async Task<bool> AddAsync(CartCreationDto cartCreationDto)
    {
        var cart = await cartRepository.SelectAsync(c => c.UserId == cartCreationDto.UserId);

        if (cart is not null)
            throw new CustomException(405, "Cart is already created");

        var mappedCart = mapper.Map<Cart>(cartCreationDto);

        mappedCart.CreatedAt = DateTime.UtcNow;

        await cartRepository.InsertAsync(mappedCart);

        await cartRepository.SaveAsync();

        return true;
    }

    public async Task<bool> DelateAsync(Expression<Func<Cart, bool>> expression)
    {
        var cart = await cartRepository.SelectAsync(expression);

        if (cart is null)
            throw new CustomException(404, "Not found");

        await cartRepository.DeleteAsync(expression);

        await cartRepository.SaveAsync();

        return true;
    }

    public async Task<IEnumerable<Cart>> GetAllAsync(
        Expression<Func<Cart, bool>> expression = null!)
        => cartRepository.SelectAllAsync();

    public async Task<Cart> GetAsync(Expression<Func<Cart, bool>> expression = null!)
    {
        var cart = await cartRepository.SelectAsync(expression);

        if (cart is null)
            throw new CustomException(404, "User not exist");

        return cart;
    }

    public async Task<bool> UpdateAsync(int id, CartForResultDto cartForResultDto)
    {
        var cart = await cartRepository.SelectAsync(o => o.Id == id);

        if (cart is null)
            throw new CustomException(404, "Not found");

        cart.UpdatedAt = DateTime.UtcNow;

        await cartRepository.UpdateAsync(cart);

        await cartRepository.SaveAsync();

        return true;
    }
}
