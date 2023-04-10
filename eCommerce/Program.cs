using eCommerce.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using eCommerce.Service.Mappers;

using eCommerce.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

#region repositories added
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("eCommerce.Data")));
builder.Services.AddAutoMapper(typeof(MappingProfile));

//Extension method for DI contiener to store All Repositories
builder.Services.AddRepositories();

//Extension method for DI contiener to store All Service
builder.Services.AddCustomServices();

#endregion
var app = builder.Build();

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
