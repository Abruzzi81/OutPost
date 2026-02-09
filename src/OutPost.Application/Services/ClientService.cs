using OutPost.Application.Abstractions;
using OutPost.Application.DTOs;
using OutPost.Application.Interfaces;
using OutPost.Domain.Entities;

namespace OutPost.Application.Services;


public class ClientService : IClientService
{
    IClientRepository _repository;

    public ClientService(IClientRepository repository)
    {
        _repository = repository;
    }


    public async Task<int> CreateClientAsync(CreateClientDto dto)
    {
        Client client = new Client(dto.Name, dto.Password, dto.Address, dto.Email, dto.Phone_Number);
        await _repository.AddAsync(client);
        await _repository.SaveChangesAsync();

        return client.Id;
    }
    public async Task<ClientDto?> GetClientByIdAsync(int id)
    {
        var client = await _repository.GetByIdAsync(id);
        if (client == null) return null;

        return new ClientDto
        {
            Id = id,
            Name = client.Name,
            Password = client.Password,
            Address = client.Address,
            Email = client.Email,
            Phone_Number = client.Phone_Number
        };
    }
    public async Task<IEnumerable<Client>> GetAllClientsAsync()
    {
        return await _repository.GetAllAsync();
    }
}