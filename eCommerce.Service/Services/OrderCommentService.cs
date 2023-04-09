using AutoMapper;
using eCommerce.Data.IRepositories;
using eCommerce.Domain.Entities;
using eCommerce.Domain.Entities.Orders;
using eCommerce.Service.DTOs.Orders;
using eCommerce.Service.Exceptions;
using eCommerce.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace eCommerce.Service.Services
{
    public class OrderCommentService : IOrderCommentService
    {
        private readonly IRepository<OrderComments> OrderCommentsRepository;
        private readonly IRepository<User> userRpository; 
        private readonly IRepository<Order> orderRepository;
        private readonly IMapper mapper;

        public OrderCommentService(IRepository<OrderComments> orderCommentrepository, IRepository<User> userRepository, IRepository<Order> orderRepository, IMapper mapper)
        {
            this.OrderCommentsRepository = orderCommentrepository;
            this.userRpository = userRepository;
            this.orderRepository = orderRepository;
            this.mapper = mapper;
        }

        public async Task<bool> DelateAsync(Expression<Func<OrderComments, bool>> expression)
        {
            var result = await OrderCommentsRepository.SelectAsync(expression);
            if (result == null)
                throw new CustomException(404, "Order is not found");

            await OrderCommentsRepository.DeleteAsync(expression);
            await OrderCommentsRepository.SaveAsync();

            return true;
        }

        public async Task<OrderCommentResultDto> LeaveComment(OrderCommentCreationDto orderCommentCreationDto)
        {
            var allUsers = userRpository.SelectAllAsync();
            var user = allUsers.FirstOrDefault(u => u.Id == orderCommentCreationDto.UserId);
            if (user == null)
                throw new CustomException(404, "User not found");

            var allOrders = orderRepository.SelectAllAsync();
            var order = allOrders.FirstOrDefault(o => o.Id == orderCommentCreationDto.OrderId);
            if (order == null)
                throw new CustomException(404, "Order not found");

            var mappedModel = mapper.Map<OrderComments>(orderCommentCreationDto);

            var result = await OrderCommentsRepository.InsertAsync(mappedModel);
            await OrderCommentsRepository.SaveAsync();

            return mapper.Map<OrderCommentResultDto>(result);
        }

        public async Task<OrderCommentResultDto> ReplyComment(string comment, OrderCommentCreationDto orderCommentCreationDto)
        {
            var allUsers = userRpository.SelectAllAsync();
            var user = allUsers.FirstOrDefault(u => u.Id == orderCommentCreationDto.UserId);
            if (user == null)
                throw new CustomException(404, "User not found");

            var allOrders = orderRepository.SelectAllAsync();
            var order = allOrders.FirstOrDefault(o => o.Id == orderCommentCreationDto.OrderId);
            if (order == null)
                throw new CustomException(404, "Order not found");

            var allComments = OrderCommentsRepository.SelectAllAsync();
            var result = allComments.FirstOrDefaultAsync(c => c.Comment.ToLower() == comment.ToLower());
            if (result == null)
            {
                throw new CustomException(404, "Comment not found");
            }

            var mappedModel = mapper.Map<OrderComments>(orderCommentCreationDto);

            await OrderCommentsRepository.InsertAsync(mappedModel);
            await OrderCommentsRepository.SaveAsync();

            return mapper.Map<OrderCommentResultDto>(mappedModel);

        }
    }
}
