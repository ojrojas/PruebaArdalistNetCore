using Application.Commons;
using Application.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Core
{
    /// <summary>
    /// Interface Negocio UserBusinessLogic
    /// </summary>
    public interface IUserBusinessLogic
    {
        /// <summary>
        /// Method create user
        /// </summary>
        /// <param name="userdto">User create</param>
        /// <author>Oscar Julian Rojas</author>
        /// <date>10/07/2021</date>
        /// <returns>User created</returns>
        Task<Response<UserDto>> CreateUser(UserDto userdto);

        /// <summary>
        /// Method delete user
        /// </summary>
        /// <param name="userdto">User to delete</param>
        /// <author>Oscar Julian Rojas</author>
        /// <date>10/07/2021</date>
        /// <returns>User deleted</returns>
        Task<Response<UserDto>> Delete(UserDto userdto);

        /// <summary>
        /// Method getall users
        /// </summary>
        /// <author>Oscar Julian Rojas</author>
        /// <date>10/07/2021</date>
        /// <returns>IEnumerable users </returns>
        Task<Response<IEnumerable<UserDto>>> GetAll();

        /// <summary>
        /// Method update user
        /// </summary>
        /// <param name="userdto">User to update</param>
        /// <author>Oscar Julian Rojas</author>
        /// <date>10/07/2021</date>
        /// <returns>User updated</returns>
        Task<Response<UserDto>> Update(UserDto userdto);

        /// <summary>
        /// Method update state user
        /// </summary>
        /// <param name="userdto">User to update state</param>
        /// <author>Oscar Julian Rojas</author>
        /// <date>10/07/2021</date>
        /// <returns>User updated</returns>
        Task<Response<UserDto>> UpdateState(UserDto userdto);
    }
}