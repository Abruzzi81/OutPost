using OutPost.Domain.Entities;

namespace OutPost.Application.Abstractions;

public interface IClientRepository
{

    // Dodawanie nowego klienta do kolejki zapisu
    Task AddAsync(Client client);

    Task<Client?> GetByIdAsync(int id);
    Task<IEnumerable<Client>> GetAllAsync();


    // Zapisywanie wszystkich zmian w bazie danych
    Task SaveChangesAsync();
    Task UpdateAsync(Client client);
}
