using AutoMapper;
using eCommerce.Data.IRepositories;
using eCommerce.Domain.Entities;
using eCommerce.Domain.Entities.Products;
using eCommerce.Service.DTOs.Products;
using eCommerce.Service.Exceptions;
using eCommerce.Service.Interfaces;
using System.Linq.Expressions;

namespace eCommerce.Service.Services
{
    public class ProductCommentService : IProductCommentService
    {
        private readonly IRepository<ProductComment> productCommentRepository;
        private readonly IRepository<Product> productRepository;
        private readonly IRepository<User> userRepository;
        private readonly IMapper mapper;

        public ProductCommentService(IRepository<ProductComment> repository, IRepository<Product> productRepository, IRepository<User> userRepository, IMapper mapper)
        {
            this.productCommentRepository = repository;
            this.productRepository = productRepository;
            this.userRepository = userRepository;
            this.mapper = mapper;
        }
        public async Task<bool> DelateAsync(Expression<Func<ProductComment, bool>> productComment)
        {
            var result=await productCommentRepository.SelectAsync(productComment);
            if (result == null)
                throw new CustomException(404, "Comment is not found");

            await productCommentRepository.DeleteAsync(productComment);
            await productCommentRepository.SaveAsync();

            return true;
        }

        public async Task<productCommentResultDto> LeaveComment(ProductCommentCreationDto productCommentCreationDto)
        {
            var allUsers = userRepository.SelectAllAsync();
            var user = allUsers.FirstOrDefault(u => u.Id == productCommentCreationDto.UserId);
            if (user == null)
                throw new CustomException(404, "User not found");

            var allProducts = productRepository.SelectAllAsync();
            var product = allProducts.FirstOrDefault(p => p.Id == productCommentCreationDto.ProductId);
            if (product == null)
            {
                throw new CustomException(404, "Given product not found");
            }

            var mappedModel = mapper.Map<ProductComment>(productCommentCreationDto);

            var result = await productCommentRepository.InsertAsync(mappedModel);
            await productCommentRepository.SaveAsync();

            return mapper.Map<productCommentResultDto>(result);
        }

        public async Task<productCommentResultDto> ReplyComment(string comment, ProductCommentCreationDto productCommentCreationDto)
        {
            var allUsers = userRepository.SelectAllAsync();
            var user = allUsers.FirstOrDefault(u => u.Id == productCommentCreationDto.UserId);
            if (user == null)
                throw new CustomException(404, "User not found");

            var allProducts = productRepository.SelectAllAsync();
            var product = allProducts.FirstOrDefault(p => p.Id == productCommentCreationDto.ProductId);
            if (product == null)
            {
                throw new CustomException(404, "Product not found");
            }
            
            List<ProductComment> allComments = productCommentRepository.SelectAllAsync().ToList();
            ProductComment beingReplied = allComments.FirstOrDefault(c => c.Comment == comment);
            if (beingReplied == null)
            {
                throw new CustomException(404, "Comment not found");
            }

            var mappedModel = mapper.Map<ProductComment> (productCommentCreationDto);

            await productCommentRepository.InsertAsync(mappedModel);
            await productCommentRepository.SaveAsync();

            return mapper.Map<productCommentResultDto>(mappedModel);
        }
    }
}
