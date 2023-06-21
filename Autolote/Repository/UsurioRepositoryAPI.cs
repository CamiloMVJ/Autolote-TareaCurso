using Autolote.Data;
using AutoloteAPI.Repository.IRepository;

namespace AutoloteAPI.Repository
{
    public class UsurioRepositoryAPI : IUsurioRepository
    {
        private readonly AutoloteContext _db;
        public UsurioRepositoryAPI(AutoloteContext? db)
        {
            _db = db;
        }
        public bool IsUser(string username, string password)
        {
            var users = _db.Users.ToList();
            return users.Where(u => u.Username == username && u.Password == password).Count() > 0;
        }
    }
}
