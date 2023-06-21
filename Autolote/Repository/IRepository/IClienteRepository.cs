using Autolote.Models;

namespace Autolote.Repository.IRepository
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        Task<Cliente> UpdateCliente(Cliente entity);
    }
}
