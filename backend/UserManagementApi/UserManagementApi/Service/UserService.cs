using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using UserManagementApi.Models;
using UserManagementApi.Repository;

namespace UserManagementApi.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        // Injeção de dependência via construtor
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> ValidateUserAsync(string email, string password)
        {
            User user = _userRepository.GetUserByEmailAsync(email).Result;

            if (user == null || !VerifyPassword(password, user.Password)) // Aqui você pode verificar o hash da senha
            {
                return null;  // Usuário ou senha inválidos
            }

            return user;
        }

        private bool VerifyPassword(string inputPassword, string storedPasswordHash)
        {
            // Aqui você deve implementar a lógica de verificação de senha (geralmente usando hash)
            return inputPassword == storedPasswordHash;
        }
        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllUsersAsync();  // Chamada assíncrona
        }

        public async Task<User> GetUserByNameAsync(string name)
        {
            return await _userRepository.GetUserByNameAsync(name);
        }

        public async Task CreateUserAsync(User user)
        {
            await _userRepository.CreateUserAsync(user);
        }

        public async Task UpdateUserAsync(int id, User user)
        {
            await _userRepository.UpdateUserAsync(id, user);
        }
    }
}