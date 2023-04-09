using AutoMapper;
using eCommerce.Data.IRepositories;
using eCommerce.Domain.Entities;
using eCommerce.Service.DTOs.Users;
using eCommerce.Service.Exceptions;
using eCommerce.Service.Interfaces;
using System.Linq.Expressions;
using System.Net.Http.Headers;

namespace eCommerce.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<User> repository;
        public UserService(IMapper mapper, IRepository<User> repository)
        {
            this._mapper = mapper;
            this.repository = repository;
        }
        public async Task<UserForResultDto> CreateAsync(UserCreationDto userCreationDto)
        {
            var user = await this.repository.SelectAsync( user => user.Email.ToLower() == userCreationDto.Email.ToLower();

            if (user is not null)
                throw new CustomException(400, "User Already exists");

            var mappedUser = this._mapper.Map<User>(userCreationDto);

            try
            {
                mappedUser.CreatedAt = DateTime.UtcNow;
                var result = await this.repository.InsertAsync(mappedUser);
                await this.repository.SaveAsync();

                return this._mapper.Map<UserForResultDto>(result);
            }
            catch (Exception)
            {
                throw new CustomException(500, "Something went wrong");
            }
        }

        public async Task<bool> DeleteAsync(Expression<Func<User, bool>> expression)
        {
            var isDeleted = await this.repository.DeleteAsync(expression);
            if (isDeleted is false)
                throw new CustomException(404, "User not found");

            await this.repository.SaveAsync();
            return isDeleted;
        }

        public async Task<IEnumerable<UserForResultDto>> GetAllAsync()
        {
            var users =  this.repository.SelectAllAsync();
            if (users is null)
                throw new CustomException(404, "Users not Found");

            try
            {
                var mapped = this._mapper.Map<IEnumerable<UserForResultDto>>(users);
                return mapped;
            }
            catch
            {
                throw new CustomException(500 ,"Something went wrong");
            }
        }

        public async Task<UserForResultDto> GetAsync(Expression<Func<User, bool>> expression)
        {
            var user = await this.repository.SelectAsync(expression);

            if(user is null)
                throw new CustomException(404, "User not Found");

            try
            {
                var model = this._mapper.Map<UserForResultDto>(user);
                return model;
            }
            catch 
            {
                throw new CustomException(500, "Something went wrong");
            }
        }

        public async Task<UserForResultDto> UpdateAsync(Expression<Func<User, bool>> expression,UserForResultDto resultDto)
        {
            var userToUpdate = await this.repository.SelectAsync(expression);

            if (userToUpdate is null)
                throw new CustomException(404, "User not found");

            try
            {
                userToUpdate.UpdatedAt = DateTime.UtcNow;
                var updated = await this.repository.UpdateAsync(userToUpdate);
                
                await this.repository.SaveAsync();
                var result = this._mapper.Map<UserForResultDto>(updated);

                return result;
            }
            catch 
            {
                throw new CustomException(500, "Something went wrong");
            }            
        }
    }
}
