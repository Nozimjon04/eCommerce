using eCommerce.Service.DTOs.Products;

namespace eCommerce.Service.Interfaces;

public interface IProductCommentService
{
	public Task<productCommentResultDto> LeaveComment(ProductCommentCreationDto productCommentCreationDto);
	public Task<productCommentResultDto> ReplyComment(ProductCommentCreationDto productCommentCreationDto);
	public Task<bool> DelateAsync(ProductCommentCreationDto productCommentCreationDto);
}
