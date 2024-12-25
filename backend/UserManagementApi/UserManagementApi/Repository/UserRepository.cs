using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Linq;
using UserManagementApi.Models;

namespace UserManagementApi.Repository
{
    public class UserRepository : IUserRepository
    {
        private static List<User> _users = new List<User>
        {
            new User { Id = 1, Name = "Admin User", Email = "admin@example.com", Password = "senha123", Permission = "admin", Phone = "123456789" },
            new User { Id = 2, Name = "Standard User", Email = "standard@example.com", Password = "hashedPassword", Permission = "standard", Phone = "987654321" }
        };

        public async Task<List<User>> GetAllUsersAsync() => _users;

        public async Task<User> GetUserByNameAsync(string name) => _users.FirstOrDefault(x => x.Name.ToLower().Contains(name));

        public async Task<User> GetUserByEmailAsync(string email)
        {
            // Verifica se o usuário existe no banco de dados usando o email
            return _users.FirstOrDefault(x => x.Email == email);
        }
        public async Task CreateUserAsync(User user)
        {
            user.Id = _users.Max(u => u.Id) + 1;
            _users.Add(user);
        }

        public async Task UpdateUserAsync(int id, User user)
        {
            var existingUser = _users.FirstOrDefault(u => u.Id == id);
            if (existingUser != null)
            {
                existingUser.Name = user.Name;
                existingUser.Email = user.Email;
                existingUser.Phone = user.Phone;
                existingUser.Permission = user.Permission;
            }
        }
    }
}