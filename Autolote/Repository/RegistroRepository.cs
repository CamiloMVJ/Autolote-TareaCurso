using Autolote.Data;
using Autolote.Models;
using Autolote.Repository.IRepository;

namespace Autolote.Repository
{
    public class RegistroRepository : Repository<RegistroVenta>, IRegistroRepository
    {
        private readonly AutoloteContext _db;
        public RegistroRepository(AutoloteContext db) : base(db)
        {
            _db = db;
        }

        public async Task<RegistroVenta> UpdateRegistro(RegistroVenta entity)
        {
            _db.RegistrosVentas.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
