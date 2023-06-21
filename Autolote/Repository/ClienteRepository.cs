using Autolote.Data;
using Autolote.Models;
using Autolote.Repository.IRepository;

namespace Autolote.Repository
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        private readonly AutoloteContext _db;
        
        public ClienteRepository(AutoloteContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Cliente> UpdateCliente(Cliente entity)
        {
            _db.Clientes.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}

