using System.Collections.Generic;
using PJ_API.Domain.Entities;

namespace PJ_API.Domain.Repositories
{
    public interface IClientRepository
    {
        void Add(Client client);
        Client? GetById(Guid id);
        IEnumerable<Client> GetAll();
    }
}
