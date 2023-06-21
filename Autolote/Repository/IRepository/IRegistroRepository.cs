using Autolote.Models;

namespace Autolote.Repository.IRepository
{
    public interface IRegistroRepository : IRepository<RegistroVenta>
    {
        Task<RegistroVenta> UpdateRegistro(RegistroVenta entity);

    }
}
