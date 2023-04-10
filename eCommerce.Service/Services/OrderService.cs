using AutoMapper;
using eCommerce.Data.IRepositories;
using eCommerce.Domain.Entities;
using eCommerce.Service.DTOs.Orders;
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

        public OrderService(IMapper mapper, IRepository<Order> repository,IUserService userService)
        {
            this.mapper = mapper;
            this.repository = repository;
            this.userService = userService;
        }
        public async Task<OrderForResultDto> AddAsync(OrderCreationDto orderDto)
        {
            var entity = await this.userService.
                GetAsync(user => user.Id == orderDto.UserId);

            if (entity == null)
                throw new CustomException(400, "No Matching User");

            if (entity is not null && orderDto.isPaid == true)
            {
              var mappedOrder=mapper.Map<Order>(orderDto); 
                
                mappedOrder.CreatedAt = DateTime.UtcNow;

                await repository.InsertAsync(mappedOrder);
                await repository.SaveAsync();

                return mapper.Map<OrderForResultDto>(mappedOrder);
            }
            throw new CustomException(500, "something went wrong");
        }

        public async Task<bool> DelateAsync(Expression<Func<Order, bool>> expression)
        {
            var isDeleted = await this.repository.DeleteAsync(expression);
            if (isDeleted is false)
                throw new CustomException(404, " Order is not found");

            var result = await this.repository.DeleteAsync(expression);
            await this.repository.SaveAsync();

            return result;
        }

        public async Task<IEnumerable<OrderForResultDto>> GetAllAsync()
        {
            var orders = this.repository.SelectAllAsync();
            if (orders is null)
                throw new CustomException(400, " Order is not found");

            try
            {
                var mapped = this.mapper.Map<IEnumerable<OrderForResultDto>>(orders);
                return mapped;
            }
            catch 
            {
                throw new CustomException(500, "Something went wrong");
            }
        }

        public async Task<OrderForResultDto> GetAsync(Expression<Func<Order, bool>> expression)
        {
            var order = await this.repository.SelectAsync(expression);
            if(order is null)
                throw new CustomException(400, " Order is not found");

            return this.mapper.Map<OrderForResultDto>(order);
        }

        public async Task<OrderForResultDto> UpdateAsync(Expression<Func<Order, bool>> expression, OrderForResultDto orderDto)
        {
            var order = await this.repository.SelectAsync(expression);

            if (order is null)
                throw new CustomException(400, " Order is not found");

            try
            {
                var mappedOrder = this.mapper.Map<Order>(orderDto);
                var result = await this.repository.UpdateAsync(mappedOrder);

                return this.mapper.Map<OrderForResultDto>(result);
            }
            catch 
            {
                throw new CustomException(500, "Something went wrong");
            }
        }
    }
}
