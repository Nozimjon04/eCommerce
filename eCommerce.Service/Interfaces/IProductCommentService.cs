using eCommerce.Domain.Entities.Products;
using eCommerce.Service.DTOs.Products;
using System.Linq.Expressions;

namespace eCommerce.Service.Interfaces;

public interface IProductCommentService
{
	public Task<productCommentResultDto> LeaveComment(ProductCommentCreationDto productCommentCreationDto);
	public Task<productCommentResultDto> ReplyComment(string comment, ProductCommentCreationDto productCommentCreationDto);
	public Task<bool> DelateAsync(Expression<Func<ProductComment,bool>> productComment);
}
