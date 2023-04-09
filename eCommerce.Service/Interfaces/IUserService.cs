using eCommerce.Domain.Entities;
using eCommerce.Service.DTOs.Users;
using System.Linq.Expressions;

namespace eCommerce.Service.Interfaces;

public interface IUserService
{
    public Task<UserForResultDto> CreateAsync(UserCreationDto userCreationDto);
    public Task<UserForResultDto> UpdateAsync(Expression<Func<User, bool>> expression, UserForResultDto forResultDto);    
    public Task<bool> DeleteAsync(Expression<Func<User,bool>> expression);
    public Task<UserForResultDto> GetAsync(Expression<Func<User, bool>> expression);
    public Task<IEnumerable<UserForResultDto>> GetAllAsync();
}
