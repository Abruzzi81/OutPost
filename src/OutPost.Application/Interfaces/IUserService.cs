using OutPost.Domain.Entities;
using OutPost.Application.DTOs;

namespace OutPost.Application.Interfaces;

public interface IUserService
{
    Task<string> CreateUserAsync(CreateUserDto dto);
    Task<UserDto?> GetUserByIdAsync(string id);
    Task<IEnumerable<User>> GetAllUsersAsync();

}