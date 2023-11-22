using ApiTecnotienda.Models;
using ApiTecnotienda.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ApiTecnotienda.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository userRepository;

        public UserController(IUserRepository userRepository)
        {
            //Por inyeccion de dependencia se crea la instancia de la clase
            this.userRepository = userRepository;
        }
        [HttpPost]
        [Route("/CreateUser")]
        public async Task<bool> CreateUser(UserTable user)
        {
            return await userRepository.CreateUser(user);
        }
        [HttpPost]
        [Route("/LoginUser")]
        public async Task<bool> LoginUser(UserTable user)
        {
            return await userRepository.LoginUser(user);
        }
    }
}
