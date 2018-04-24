using System;
using System.Threading.Tasks;
using UserRegistration.Persistance;
using UserRegistration.Persistance.Model;

namespace UserRegistration
{
    public class UserRegistrationService : IUserRegistrationService
    {
        private readonly UsersDbContext _usersDbContext;

        public UserRegistrationService(UsersDbContext usersDbContext)
        {
            _usersDbContext = usersDbContext;
        }

        public Task ActivateUserAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public async Task RegisterUserAsync(User user)
        {
            _usersDbContext.Add<User>(user);
            await _usersDbContext.SaveChangesAsync();
        }
    }
}