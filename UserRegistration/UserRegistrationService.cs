using System;
using System.Threading.Tasks;
using System.Transactions;
using Confluent.Kafka;
using Newtonsoft.Json;
using UserRegistration.ClientModel;
using UserRegistration.Persistance;
using UserRegistration.Persistance.Model;

namespace UserRegistration
{
    public class UserRegistrationService : IUserRegistrationService
    {
        private readonly UsersDbContext _usersDbContext;
        private readonly IStreamProducer<int, string> _producer;

        public UserRegistrationService(UsersDbContext usersDbContext, IStreamProducer<int, string> producer)
        {
            _usersDbContext = usersDbContext;
            _producer = producer;
        }

        public Task ActivateUserAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public async Task RegisterUserAsync(NewUser newUser)
        {
            using(var transaction = await _usersDbContext.Database.BeginTransactionAsync())
            {
                var addUser = new User{
                    FirstName = newUser.FirstName,
                    LastName = newUser.LastName,
                    RegistrationDate = DateTime.UtcNow
                };
                
                _usersDbContext.Add<User>(addUser);

                await _usersDbContext.SaveChangesAsync();

                string userJson = JsonConvert.SerializeObject(addUser);

                StreamProduceResult dr = await _producer.ProduceAsync("user-registration", addUser.Id, userJson);

                if(dr.Exception != null)  
                {
                    throw dr.Exception;
                } 
                
                transaction.Commit();
            }
        }
    }
}