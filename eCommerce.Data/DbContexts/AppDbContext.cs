using eCommerce.Domain.Entities;
using eCommerce.Domain.Entities.Carts;
using eCommerce.Domain.Entities.Orders;
using eCommerce.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace eCommerce.Data.DbContexts;

public class AppDbContext:DbContext
{
	public AppDbContext(DbContextOptions<AppDbContext> options)
		:base(options)
	{

	}
	DbSet<User> Users { get; set; }
	DbSet<Payment> Payments { get; set; }	
	DbSet<Product> Products { get; set;}
	DbSet<Order> Orders { get;set; }
	DbSet<ProductComment> ProductComments { get; set; }
	DbSet<Cart> Carts { get; set; }
	DbSet<CartProduct> CartProducts { get; set; }
	DbSet<OrderComments> OrderComments { get; set; }


}
