using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using UserManagementApi.Models;

namespace UserManagementApi.Repository
{
    public interface IUserRepository
    {
        
        Task<List<User>> GetAllUsersAsync();
        Task<User> GetUserByNameAsync(string name);
        Task<User> GetUserByEmailAsync(string email);
        Task CreateUserAsync(User user);
        Task UpdateUserAsync(int id, User user);
    }
}