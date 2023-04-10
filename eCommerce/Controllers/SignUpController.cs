using AutoMapper.Configuration;
using eCommerce.Domain.Entities;
using eCommerce.Service.DTOs.Users;
using eCommerce.Service.Interfaces;
using eCommerce.Service.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace eCommerce.Controllers
{
    public class SignUpController : Controller
    {
        private readonly IUserService userService;

        public SignUpController(IUserService userService)
        {
            this.userService = userService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserCreationDto dto)
        {
            if (ModelState.IsValid)
            {
                await userService.CreateAsync(dto);
                ViewBag.Message = "Sign up successful!";
                return View();
            }
            else
            {
                return View(dto);
            }
        }
        }
}
