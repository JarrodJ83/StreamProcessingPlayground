using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserRegistration.Persistance.Model
{
    [Table(nameof(User))]
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
