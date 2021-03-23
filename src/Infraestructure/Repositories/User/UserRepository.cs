using Application.Commons;
using Application.Data;
using Application.Entities;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Application.Repositories
{
    /// <summary>
    /// User Repository
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>20/03/2021</date>
    public class UserRepository : GenerycRepository, IUserRepository
    {
        /// <summary>
        /// Contructor Repository User
        /// </summary>
        /// <param name="configuration">Configuration Api application.Api</param>
        public UserRepository(IConfiguration configuration) : base(configuration) { }

        /// <summary>
        /// Create User Method repository
        /// </summary>
        /// <param name="user">User Entity</param>
        /// <returns>User entity create</returns>
        public async Task<User> CreateUser(User user)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumUserParameters.ID), Guid.NewGuid());
            parameters.Add(HelpersEnums.GetEnumDescription(EnumUserParameters.NAME), user.Name);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumUserParameters.MIDDLE_NAME), user.MiddleName);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumUserParameters.LAST_NAME), user.LastName);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumUserParameters.SUR_NAME), user.SurName);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumUserParameters.EMAIL), user.Email);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumUserParameters.PASSWORD), user.Password);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumUserParameters.MODIFIED_BY), user.ModifiedBy);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumUserParameters.MODIFIED_ON), user.ModifiedOn);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumUserParameters.CREATED_BY), user.CreatedBy);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumUserParameters.CREATED_ON), user.CreatedOn);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumUserParameters.IDENTIFICATION_TYPE), user.TypeIdentificationId);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumUserParameters.IDENTIFICATION), user.Identification);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumUserParameters.STATE), user.State);

            return await GetAsyncFirst<User>(UserQuerys.CreateUser, parameters, CommandType.Text);
        }

        /// <summary>
        /// Update user repository method 
        /// </summary>
        /// <param name="user">User entity</param>
        /// <returns>User updated</returns>
        /// <author>Oscar Julian Rojas</author>
        /// <date>20/03/2021</date>
        public async Task<User> UpdateUser(User user)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumUserParameters.ID), Guid.NewGuid());
            parameters.Add(HelpersEnums.GetEnumDescription(EnumUserParameters.NAME), user.Name);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumUserParameters.MIDDLE_NAME), user.MiddleName);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumUserParameters.LAST_NAME), user.LastName);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumUserParameters.SUR_NAME), user.SurName);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumUserParameters.EMAIL), user.Email);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumUserParameters.PASSWORD), user.Password);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumUserParameters.IDENTIFICATION_TYPE), user.TypeIdentificationId);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumUserParameters.IDENTIFICATION), user.Identification);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumUserParameters.STATE), user.State);

            return await GetAsyncFirst<User>(UserQuerys.UpdateUser, parameters, CommandType.Text);
        }

        /// <summary>
        /// Update state user
        /// </summary>
        /// <param name="user">User stated changed</param>
        /// <returns>Entity user stated</returns>
        /// <author>Oscar Julian Rojas</author>
        /// <date>20/03/2021</date>
        public async Task<User> UpdateStateUser(User user)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumUserParameters.ID), Guid.NewGuid());
            parameters.Add(HelpersEnums.GetEnumDescription(EnumUserParameters.STATE), user.State);

            return await GetAsyncFirst<User>(UserQuerys.UpdateStateUser, parameters, CommandType.Text);
        }

        /// <summary>
        /// Delete user method
        /// </summary>
        /// <param name="user">User entity</param>
        /// <returns>User deleted confirm</returns>
        /// <author>Oscar Julian Rojas</author>
        /// <date>20/03/2021</date>
        public async Task<User> DeleteUser(User user)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumUserParameters.ID), user.Id);

            return await GetAsyncFirst<User>(UserQuerys.DeleteUser, parameters, CommandType.Text);
        }

        /// <summary>
        /// Select login user
        /// </summary>
        /// <param name="user"></param>
        /// <returns>User found username password</returns>
        /// <author>Oscar Julian Rojas</author>
        /// <date>20/03/2021</date>
        public async Task<User> SelectLoginUser(User user)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumUserParameters.EMAIL), user.Email);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumUserParameters.PASSWORD), user.Password);

            return await GetAsyncFirst<User>(UserQuerys.SelectLoginUser, parameters, CommandType.Text);
        }

        /// <summary>
        /// Method getall users
        /// </summary>
        /// <returns>All users</returns>
        /// <author>Oscar Julian Rojas</author>
        /// <date>20/03/2021</date>
        public async Task<IEnumerable<User>> GetAllUser()
        {
            return await GetAsync<User>(UserQuerys.SelectUser, null, CommandType.Text);
        }


        /// <summary>
        /// Method select for update password
        /// </summary>
        /// <returns>All users</returns>
        /// <author>Oscar Julian Rojas</author>
        /// <date>20/03/2021</date>
        public async Task<User> SelectUpdatePassword(User user, string oldpassword)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumUserParameters.ID), user.Id);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumUserParameters.PASSWORD), oldpassword);

            return await GetAsyncFirst<User>(UserQuerys.SelectUpdatePasswordUser, parameters, CommandType.Text);
        }

        /// <summary>
        /// Method update password
        /// </summary>
        /// <returns>All users</returns>
        /// <author>Oscar Julian Rojas</author>
        /// <date>20/03/2021</date>
        public async Task<User> UpdatePassword(User user)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add(HelpersEnums.GetEnumDescription(EnumUserParameters.ID), user.Id);
            parameters.Add(HelpersEnums.GetEnumDescription(EnumUserParameters.PASSWORD), user.Password);

            return await GetAsyncFirst<User>(UserQuerys.SelectUser, parameters, CommandType.Text);
        }
    }
}
