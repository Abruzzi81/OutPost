using OutPost.Domain.Entities;
using OutPost.Application.DTOs;

namespace OutPost.Application.Interfaces;

public interface IUserService
{
    Task<string> CreateClientAsync(CreateUserDto dto);
    Task<UserDto?> GetClientByIdAsync(string id);
    Task<IEnumerable<User>> GetAllClientsAsync();

}