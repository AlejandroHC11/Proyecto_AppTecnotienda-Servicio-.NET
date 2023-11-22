using ApiTecnotienda.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiTecnotienda.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly BDTecnotiendaContext dbContext;
        public UserRepository(BDTecnotiendaContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<bool> CreateUser(UserTable user)
        {
            try
            {
                dbContext.UserTables.Add(user);
                await dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> LoginUser(UserTable user)
        {
            var existingUser = await dbContext.UserTables
            .Where(p => p.UserData == user.UserData)
            .FirstOrDefaultAsync();
            if (existingUser != null && existingUser.PasswordData == user.PasswordData)
            {
                return true;
            }

            return false;

        }
    }
}
