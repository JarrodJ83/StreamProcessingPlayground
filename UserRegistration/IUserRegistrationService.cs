using System;
using System.Threading.Tasks;
using UserRegistration.ClientModel;

namespace UserRegistration
{
    public interface IUserRegistrationService
    {
        Task RegisterUserAsync(NewUser user);
        Task ActivateUserAsync(Guid userId);
    }
}