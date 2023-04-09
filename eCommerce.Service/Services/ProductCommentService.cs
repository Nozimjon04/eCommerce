using AutoMapper;
using eCommerce.Data.IRepositories;
using eCommerce.Domain.Entities.Products;
using eCommerce.Service.DTOs.Products;
using eCommerce.Service.Exceptions;
using eCommerce.Service.Interfaces;
using System.Linq.Expressions;

namespace eCommerce.Service.Services
{
    public class ProductCommentService : IProductCommentService
    {
        private readonly IRepository<ProductComment> repository;
        private readonly IMapper mapper;

        public ProductCommentService(IRepository<ProductComment> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<bool> DelateAsync(Expression<Func<ProductComment, bool>> productComment)
        {
            var result=await repository.SelectAsync(productComment);
            if (result == null)
                throw new CustomException(404, "Comment is not found");

            await repository.DeleteAsync(productComment);
            await repository.SaveAsync();

            return true;
        }

        public async Task<productCommentResultDto> LeaveComment(ProductCommentCreationDto productCommentCreationDto)
        {
            //mapping from productCommentCreationDto to ProductComment
            var mappedModel = mapper.Map<ProductComment>(productCommentCreationDto);

            //Adding mappedModel(ProductComment) to database
            var result = await repository.InsertAsync(mappedModel);
            await repository.SaveAsync();

            return mapper.Map<productCommentResultDto>(result);
        }

        public async Task<productCommentResultDto> ReplyComment(string comment, ProductCommentCreationDto productCommentCreationDto)
        {
            List<ProductComment> allComments = repository.SelectAllAsync().ToList();
            ProductComment beingReplied = allComments.FirstOrDefault(c => c.Comment == comment);
            
            var mappedModel = mapper.Map<ProductComment> (productCommentCreationDto);

            await repository.InsertAsync(mappedModel);
            await repository.SaveAsync();

            return mapper.Map<productCommentResultDto>(mappedModel);
        }
    }
}
