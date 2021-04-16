using System.ComponentModel.DataAnnotations.Schema;

namespace BorrowMyGameDotNet.Modules.Auth.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public User()
        {
        }

        public User(int id, string email, string password, string role)
        {
            Id = id;
            Email = email;
            Password = password;
            Role = role;
        }
    }
}