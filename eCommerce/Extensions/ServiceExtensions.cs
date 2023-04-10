using eCommerce.Data.IRepositories;
using eCommerce.Data.Repositories;
using eCommerce.Domain.Entities;
using eCommerce.Domain.Entities.Carts;
using eCommerce.Domain.Entities.Orders;
using eCommerce.Domain.Entities.Products;
using eCommerce.Service.Interfaces;
using eCommerce.Service.Services;

namespace eCommerce.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IRepository<User>,Repository<User>>();
            services.AddScoped<IRepository<Order>, Repository<Order>>();
            services.AddScoped<IRepository<OrderItem>, Repository<OrderItem>>();
            services.AddScoped<IRepository<OrderComments>, Repository<OrderComments>>();
            services.AddScoped<IRepository<Product>,Repository<Product>>();
            services.AddScoped<IRepository<ProductComment>, Repository<ProductComment>>();
            services.AddScoped<IRepository<Cart>, Repository<Cart>>();
            services.AddScoped<IRepository<CartProduct>, Repository<CartProduct>>();
            services.AddScoped<IRepository<Payment>, Repository<Payment>>();
        }
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderItemService, OrderItemService>();
            services.AddScoped<IOrderCommentService, OrderCommentService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IProductCommentService, ProductCommentService>();
            services.AddScoped<ICartService, CartService>();
            services.AddScoped<ICartProductService, CartProductService>();
        }
    }
}
