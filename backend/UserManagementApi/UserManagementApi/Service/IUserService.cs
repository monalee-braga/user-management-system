using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using UserManagementApi.Models;

namespace UserManagementApi.Service
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsersAsync();
        Task<User> GetUserByNameAsync(string name);
        Task CreateUserAsync(User user);
        Task UpdateUserAsync(User user);
    }
}