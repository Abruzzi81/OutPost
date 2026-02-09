using OutPost.Application.Abstractions;
using OutPost.Application.DTOs;
using OutPost.Application.Interfaces;
using OutPost.Domain.Entities;

namespace OutPost.Application.Services;


public class UserService : IUserService
{
    IClientRepository _repository;

    public UserService(IClientRepository repository)
    {
        _repository = repository;
    }


    public async Task<string> CreateClientAsync(CreateUserDto dto)
    {
        User user = new User(dto.Name, dto.Address, dto.Phone_Number);
        await _repository.AddAsync(user);
        await _repository.SaveChangesAsync();

        return user.Id;
    }
    public async Task<UserDto?> GetClientByIdAsync(string id)
    {
        var user = await _repository.GetByIdAsync(id);
        if (user == null) return null;

        return new UserDto
        {
            Name = user.Name,
            Address = user.Address,
            Phone_Number = user.Phone_Number
        };
    }
    public async Task<IEnumerable<User>> GetAllClientsAsync()
    {
        return await _repository.GetAllAsync();
    }
}