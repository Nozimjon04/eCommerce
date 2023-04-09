using eCommerce.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using eCommerce.Service.Mappers;
using eCommerce.Data.IRepositories;
using eCommerce.Domain.Entities;
using eCommerce.Data.Repositories;
using eCommerce.Domain.Entities.Products;
using eCommerce.Domain.Entities.Orders;
using eCommerce.Domain.Entities.Carts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

#region repositories added
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("eCommerce")));
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddScoped<IRepository<User>,Repository<User>>();
builder.Services.AddScoped<IRepository<Product>,Repository<Product>>();
builder.Services.AddScoped < IRepository < ProductComment >, Repository < ProductComment >> ();
builder.Services.AddScoped<IRepository<Payment>, Repository<Payment>> ();
builder.Services.AddScoped<IRepository<Order>, Repository<Order>> ();
builder.Services.AddScoped<IRepository<OrderComments>, Repository<OrderComments>>();
builder.Services.AddScoped<IRepository<Cart>,Repository<Cart>> ();
builder.Services.AddScoped<IRepository<CartProduct>,Repository<CartProduct>> ();
var app = builder.Build();

#endregion

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
