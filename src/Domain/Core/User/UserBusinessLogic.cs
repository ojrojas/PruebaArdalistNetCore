using Application.Dtos;
using Application.Entities;
using Application.Main;
using Application.Repositories;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Core
{
    /// <summary>
    /// Logica Negocio UserBusinessLogic
    /// </summary>
    public class UserBusinessLogic : IUserBusinessLogic
    {
        /// <summary>
        /// User repository
        /// </summary>
        private readonly IUserRepository _userRepository;
        private readonly ITypeIdentificationRepository _typeIdentificationRepository;
        private readonly IEncryptedPassword _encriptedPassword;
        private readonly IMapper _mapper;

        public UserBusinessLogic(IUserRepository userRepository, ITypeIdentificationRepository typeIdentificationRepository, IEncryptedPassword encriptedPassword, IMapper mapper)
        {
            _userRepository = userRepository;
            _typeIdentificationRepository = typeIdentificationRepository;
            _encriptedPassword = encriptedPassword;
            _mapper = mapper;
        }



        /// <summary>
        /// Method create user
        /// </summary>
        /// <param name="userdto">User create</param>
        /// <author>Oscar Julian Rojas</author>
        /// <date>20/03/2021</date>
        /// <returns>User created</returns>
        public async Task<UserDto> CreateUser(UserDto userdto)
        {
            userdto.Password = await this._encriptedPassword.GenerateEncryptedPasswordAsync(userdto.Password);
            var user = this._mapper.Map<User>(userdto);
            return this._mapper.Map<UserDto>(await this._userRepository.CreateUser(user));
        }

        /// <summary>
        /// Method update user
        /// </summary>
        /// <param name="userdto">User to update</param>
        /// <author>Oscar Julian Rojas</author>
        /// <date>20/03/2021</date>
        /// <returns>User updated</returns>
        public async Task<UserDto> Update(UserDto userdto)
        {
            var user = this._mapper.Map<User>(userdto);
            return this._mapper.Map<UserDto>(await this._userRepository.UpdateUser(user));
        }

        /// <summary>
        /// Method update state user
        /// </summary>
        /// <param name="userdto">User to update state</param>
        /// <author>Oscar Julian Rojas</author>
        /// <date>20/03/2021</date>
        /// <returns>User updated</returns>
        public async Task<UserDto> UpdateState(UserDto userdto)
        {
            var user = this._mapper.Map<User>(userdto);
            return this._mapper.Map<UserDto>(await this._userRepository.UpdateStateUser(user));
        }

        /// <summary>
        /// Method delete user
        /// </summary>
        /// <param name="userdto">User to delete</param>
        /// <author>Oscar Julian Rojas</author>
        /// <date>20/03/2021</date>
        /// <returns>User deleted</returns>
        public async Task<UserDto> Delete(UserDto userdto)
        {
            var user = this._mapper.Map<User>(userdto);
            return this._mapper.Map<UserDto>(await this._userRepository.DeleteUser(user));
        }

        /// <summary>
        /// Method getall users
        /// </summary>
        /// <author>Oscar Julian Rojas</author>
        /// <date>20/03/2021</date>
        /// <returns>IEnumerable users </returns>
        public async Task<IEnumerable<UserDto>> GetAll()
        {
            var users = await this._userRepository.GetAllUser();
            var types = await this._typeIdentificationRepository.GetAll();
            if (users.Any())
            {
                foreach (var i in users)
                {
                    i.TypeIdentification = types.Where(x => x.Id == i.TypeIdentificationId).FirstOrDefault();
                }
            }
            return this._mapper.Map<IEnumerable<UserDto>>(users);
        }

        /// <summary>
        /// Update Password getall users
        /// </summary>
        /// <author>Oscar Julian Rojas</author>
        /// <date>20/03/2021</date>
        /// <returns>IEnumerable users </returns>
        public async Task<UserDto> UpdatePassword(UserDto userdto, string oldpassword)
        {
            userdto.Password = await this._encriptedPassword.GenerateEncryptedPasswordAsync(userdto.Password);
            var user = this._mapper.Map<User>(userdto);
            var userSelected = await this._userRepository.SelectUpdatePassword(user, oldpassword);
            if (userSelected.Password.Equals(userdto.Password))
            {
                await this._userRepository.UpdatePassword(user);
                return this._mapper.Map<UserDto>(user);
            }

            return null;
        }
    }
}
