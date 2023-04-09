using eCommerce.Service.DTOs.Orders;

namespace eCommerce.Service.Interfaces;

public interface IOrderCommentService
{
	public Task<OrderForResultDto> LeaveComment(OrderCreationDto orderCreationDto);
	public Task<OrderForResultDto> ReplyComment(OrderForResultDto orderForResultDto);
	public Task<bool> DelateAsync(OrderCreationDto orderCreationDto);
}
