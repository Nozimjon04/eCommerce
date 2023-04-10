using eCommerce.Domain.Entities.Orders;
using eCommerce.Service.DTOs.Orders;
using System.Linq.Expressions;

namespace eCommerce.Service.Interfaces;

public interface IOrderCommentService
{
	public Task<OrderCommentResultDto> LeaveComment(OrderCommentCreationDto orderCommentCreationDto);
	public Task<OrderCommentResultDto> ReplyComment(string comment, OrderCommentCreationDto orderCommentCreationDto);
	public Task<bool> DelateAsync(Expression<Func<OrderComments, bool>> expression);
}
