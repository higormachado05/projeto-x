using System.Collections.Generic;
using System.Linq;
using PJ_API.Domain.Entities;
using PJ_API.Domain.Repositories;

namespace PJ_API.Infrastructure.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private static readonly List<Client> _clients = new();
        public void Add(Client client)
        {
            client.Id = Guid.NewGuid();
            _clients.Add(client);
        }
        public Client? GetById(Guid id) => _clients.FirstOrDefault(c => c.Id == id);
        public IEnumerable<Client> GetAll() => _clients;
    }
}
