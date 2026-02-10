//using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using OutPost.Application.Abstractions;
using OutPost.Application.DTOs;
using OutPost.Application.Interfaces;
using OutPost.Domain.Entities;
using System.Reflection;
using static System.Formats.Asn1.AsnWriter;


namespace OutPost.Application.Services;


public class UserService : IUserService
{
    private readonly IUserRepository _repository;
    private readonly UserManager<User> _userManager;

    public UserService(UserManager<User> userManager, IUserRepository repository)
    {
        _repository = repository;
        _userManager = userManager;
    }


    public async Task<string> CreateUserAsync(CreateUserDto dto)
    {
        User user = new User(dto.Name, dto.Address, dto.Phone_Number);
        user.UserName = dto.Name;
        user.Email = dto.Email;
        var result = await _userManager.CreateAsync(user, dto.Password);

        if (result.Succeeded)
        {
            await _userManager.AddToRoleAsync(user, "User");
        }
        else
        {
            //pobieramy listę błędów od Microsoft Identity
            var errors = string.Join(", ", result.Errors.Select(e => e.Description));

            // Rzucamy wyjątek – to sprawi, że Swagger pokaże błąd 500 lub 400 z opisem
            throw new Exception($"ZAPIS DO BAZY NIEUDANY: {errors}");
        }

        return user.Id;
    }
    public async Task<UserDto?> GetUserByIdAsync(string id)
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
    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        return await _repository.GetAllAsync();
    }
}