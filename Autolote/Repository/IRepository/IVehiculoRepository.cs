using Autolote.Models;

namespace Autolote.Repository.IRepository
{
    public interface IVehiculoRepository : IRepository<Vehiculo>
    {
        Task<Vehiculo> UpdateVehiculo(Vehiculo entity);
    }
}
