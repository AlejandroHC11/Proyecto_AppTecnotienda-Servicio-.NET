using ApiTecnotienda.Models;

namespace ApiTecnotienda.Repositories
{
    public interface IUserRepository
    {
        Task<bool> CreateUser(UserTable user);
        Task<bool> LoginUser(UserTable user);
    }
}
