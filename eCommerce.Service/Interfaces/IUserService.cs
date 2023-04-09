using eCommerce.Service.DTOs.Users;
using System.Linq.Expressions;

namespace eCommerce.Service.Interfaces;

public interface IUserService
{
    public Task<UserForResultDto> CreateAsync(UserCreationDto userCreationDto);
    public Task<UserForResultDto> UpdateAsync(Expression<Func<UserForResultDto, bool>> expression);    
    public Task<UserForResultDto> DeleteAsync(Expression<Func<UserCreationDto,bool>> expression);
    public Task<UserForResultDto> GetAsync(Expression<Func<UserCreationDto, bool>> expression);
    public Task<IEnumerable<UserForResultDto>> GetAllAsync();
}
