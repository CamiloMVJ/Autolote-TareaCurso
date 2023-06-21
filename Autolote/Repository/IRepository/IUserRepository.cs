using Autolote.Models;
using Autolote.Repository.IRepository;
using AutoloteAPI.Models;

namespace AutoloteAPI.Repository.IRepository
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> UpdateUser(User entity);

    }
}
