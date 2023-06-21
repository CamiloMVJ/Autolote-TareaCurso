using Autolote.Data;
using Autolote.Repository;
using AutoloteAPI.Models;
using AutoloteAPI.Repository.IRepository;

namespace AutoloteAPI.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly AutoloteContext _db;
        public UserRepository(AutoloteContext db) : base(db)
        {
            _db = db;
        }

        public async Task<User> UpdateUser(User entity)
        {
            _db.Users.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
