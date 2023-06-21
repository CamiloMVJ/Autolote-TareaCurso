using Autolote.Data;
using Autolote.Models;
using Autolote.Repository.IRepository;

namespace Autolote.Repository
{
    public class VehiculoRepository : Repository<Vehiculo>, IVehiculoRepository
    {
        private readonly AutoloteContext _db;
        public VehiculoRepository(AutoloteContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Vehiculo> UpdateVehiculo(Vehiculo entity)
        {
            _db.Vehiculos.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
