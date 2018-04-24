using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserRegistration.Persistance.Model;

namespace UserRegistration.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IUserRegistrationService _userRegistrationService;

        public UsersController(IUserRegistrationService userRegistrationService)
        {
            _userRegistrationService = userRegistrationService;
        }

        [HttpPost]
        public async Task AddUser([FromBody]User user)
        {
            await _userRegistrationService.RegisterUserAsync(user);   
        }
    }
}