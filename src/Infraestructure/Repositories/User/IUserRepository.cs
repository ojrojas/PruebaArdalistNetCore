using Application.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface IUserRepository
    {
        Task<User> CreateUser(User user);
        Task<User> DeleteUser(User user);
        Task<IEnumerable<User>> GetAllUser();
        Task<User> SelectLoginUser(User user);
        Task<User> SelectUpdatePassword(User user, string oldpassword);
        Task<User> UpdatePassword(User user);
        Task<User> UpdateStateUser(User user);
        Task<User> UpdateUser(User user);
    }
}