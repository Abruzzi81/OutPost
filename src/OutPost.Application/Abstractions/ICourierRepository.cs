using OutPost.Domain.Entities;


namespace OutPost.Application.Abstractions;

public interface ICourierRepository
{


    // Dodawanie nowego kuriera do kolejki zapisu
    Task AddAsync(Courier courier);

    Task<Courier?> GetByIdAsync(int id);
    Task<IEnumerable<Courier>> GetAllAsync();

    // Zapisywanie wszystkich zmian w bazie danych
    Task SaveChangesAsync();

    Task UpdateAsync(Courier courier);
}
