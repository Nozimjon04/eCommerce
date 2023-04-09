using AutoMapper;
using eCommerce.Data.IRepositories;
using eCommerce.Domain.Entities;
using eCommerce.Service.DTOs.Order;
using eCommerce.Service.Exceptions;
using eCommerce.Service.Interfaces;
using System.Linq.Expressions;

namespace eCommerce.Service.Services
{
    public class OrderService : IOrderService
    {
        private readonly IMapper mapper;
        private readonly IRepository<Order> repository;
        private readonly IUserService userService;

        public OrderService(IMapper mapper, IRepository<Order> repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }
        public async Task<OrderForResultDto> AddAsync(OrderCreationDto orderDto)
        {
            var entity = await this.userService.GetAsync(user => user.Id == orderDto.UserId);
            if (entity == null)
                throw new CustomException(400, "No Matching User");

            var order = 

           
        }

        public Task<bool> DelateAsync(Expression<Func<OrderCreationDto, bool>> expression)
        {

        }

        public Task<IEnumerable<OrderForResultDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<OrderForResultDto> GetAsync(Expression<Func<OrderCreationDto, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<OrderForResultDto> UpdateAsync(OrderForResultDto orderForResultDto)
        {
            throw new NotImplementedException();
        }
    }
}
