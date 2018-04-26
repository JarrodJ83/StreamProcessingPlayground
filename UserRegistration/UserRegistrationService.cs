using System;
using System.Threading.Tasks;
using System.Transactions;
using Confluent.Kafka;
using UserRegistration.Persistance;
using UserRegistration.Persistance.Model;

namespace UserRegistration
{
    public class UserRegistrationService : IUserRegistrationService
    {
        private readonly UsersDbContext _usersDbContext;
        private readonly IStreamProducer<Null, string> _producer;

        public UserRegistrationService(UsersDbContext usersDbContext, IStreamProducer<Null, string> producer)
        {
            _usersDbContext = usersDbContext;
            _producer = producer;
        }

        public Task ActivateUserAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public async Task RegisterUserAsync(User user)
        {
            using(var transaction = await _usersDbContext.Database.BeginTransactionAsync())
            {
                _usersDbContext.Add<User>(user);
                await _usersDbContext.SaveChangesAsync();

                StreamProduceResult dr = await _producer.ProduceAsync("foo2", null, $"User {user.Id} registered");

                transaction.Commit();
            }
        }
    }
}