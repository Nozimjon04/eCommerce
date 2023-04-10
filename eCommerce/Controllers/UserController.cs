using eCommerce.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService service;
        public UserController(IUserService userService)
        {
            this.service = userService;
        }

        public async Task<ActionResult> Index() 
        {
            var users = await this.service.GetAllAsync();
            return View(users);
        }

       
    }
}
