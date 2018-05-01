using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserRegistration.ClientModel;

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
        public async Task AddUser([FromBody]NewUser newUser)
        {
            await _userRegistrationService.RegisterUserAsync(newUser);   
        }
    }
}