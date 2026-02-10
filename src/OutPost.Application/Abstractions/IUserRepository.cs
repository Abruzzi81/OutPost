using OutPost.Domain.Entities;

namespace OutPost.Application.Abstractions;

public interface IUserRepository
{

    // Dodawanie nowego klienta do kolejki zapisu
    Task AddAsync(User client);

    Task<User?> GetByIdAsync(string id);
    Task<IEnumerable<User>> GetAllAsync();


    // Zapisywanie wszystkich zmian w bazie danych
    Task SaveChangesAsync();
    Task UpdateAsync(User client);
}
