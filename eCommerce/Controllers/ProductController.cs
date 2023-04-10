using eCommerce.Service.DTOs.Products;
using eCommerce.Service.Interfaces;
using eCommerce.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService service;
        public ProductController(IProductService service)
        {
            this.service = service;
        }
        public async Task<IActionResult> Index()
        {
            var products = await service.GetAllAsync();

            return View(products);
        }
    }
}
