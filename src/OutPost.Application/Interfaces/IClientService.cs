using OutPost.Domain.Entities;
using OutPost.Application.DTOs;

namespace OutPost.Application.Interfaces;

public interface IClientService
{
    Task<int> CreateClientAsync(CreateClientDto dto);
    Task<ClientDto?> GetClientByIdAsync(int id);
    Task<IEnumerable<Client>> GetAllClientsAsync();

}