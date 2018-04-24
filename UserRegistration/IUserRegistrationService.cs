using System;
using System.Threading.Tasks;
using UserRegistration.Persistance.Model;

namespace UserRegistration
{
    public interface IUserRegistrationService
    {
        Task RegisterUserAsync(User user);
        Task ActivateUserAsync(Guid userId);
    }
}