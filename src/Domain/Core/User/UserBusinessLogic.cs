using Application.Commons;
using Application.Commons.Constants;
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
        /// <date>10/07/2021</date>
        /// <returns>User created</returns>
        public async Task<Response<UserDto>> CreateUser(UserDto userdto)
        {
            var response = new Response<UserDto>();
            response.GetCorrelation();

            userdto.Password = await this._encriptedPassword.GenerateEncryptedPasswordAsync(userdto.Password);
            var user = this._mapper.Map<User>(userdto);
            var result = await this._userRepository.CreateUser(user);
            response.Data =  this._mapper.Map<UserDto>(result);
            response.ReturnMessage = result != null ? ConstantesUsers.CreateUserOk : ConstantesUsers.CreateUserFailure;

            return response;
        }

        /// <summary>
        /// Method update user
        /// </summary>
        /// <param name="userdto">User to update</param>
        /// <author>Oscar Julian Rojas</author>
        /// <date>10/07/2021</date>
        /// <returns>User updated</returns>
        public async Task<Response<UserDto>> Update(UserDto userdto)
        {
            var response = new Response<UserDto>();
            response.GetCorrelation();

            userdto.Password = await this._encriptedPassword.GenerateEncryptedPasswordAsync(userdto.Password);
            var user = this._mapper.Map<User>(userdto);
            var result = await this._userRepository.UpdateUser(user);
            response.Data = this._mapper.Map<UserDto>(result);
            response.ReturnMessage = result != null ? ConstantesUsers.UpdateUserOk : ConstantesUsers.UpdateUserFailure;

            return response;
        }

        /// <summary>
        /// Method update state user
        /// </summary>
        /// <param name="userdto">User to update state</param>
        /// <author>Oscar Julian Rojas</author>
        /// <date>10/07/2021</date>
        /// <returns>User updated</returns>
        public async Task<Response<UserDto>> UpdateState(UserDto userdto)
        {
            var response = new Response<UserDto>();
            response.GetCorrelation();

            userdto.Password = await this._encriptedPassword.GenerateEncryptedPasswordAsync(userdto.Password);
            var user = this._mapper.Map<User>(userdto);
            var result = await this._userRepository.UpdateStateUser(user);
            response.Data = this._mapper.Map<UserDto>(result);
            response.ReturnMessage = result != null ? ConstantesUsers.UpdateUserOk : ConstantesUsers.UpdateUserFailure;

            return response;
        }

        /// <summary>
        /// Method delete user
        /// </summary>
        /// <param name="userdto">User to delete</param>
        /// <author>Oscar Julian Rojas</author>
        /// <date>10/07/2021</date>
        /// <returns>User deleted</returns>
        public async Task<Response<UserDto>> Delete(UserDto userdto)
        {
            var response = new Response<UserDto>();
            response.GetCorrelation();

            userdto.Password = await this._encriptedPassword.GenerateEncryptedPasswordAsync(userdto.Password);
            var user = this._mapper.Map<User>(userdto);
            var result = await this._userRepository.DeleteUser(user);
            response.Data = this._mapper.Map<UserDto>(result);
            response.ReturnMessage = result != null ? ConstantesUsers.DeleteUserOk : ConstantesUsers.DeleteUserFailure;

            return response;
        }

        /// <summary>
        /// Method getall users
        /// </summary>
        /// <author>Oscar Julian Rojas</author>
        /// <date>10/07/2021</date>
        /// <returns>IEnumerable users </returns>
        public async Task<Response<IEnumerable<UserDto>>> GetAll()
        {
            var response = new Response<IEnumerable<UserDto>>();
            response.GetCorrelation();
            var users = await this._userRepository.GetAllUser();
            var types = await this._typeIdentificationRepository.GetAll();
            if (users.Any())
            {
                foreach (var i in users)
                {
                    i.TypeIdentification = types.Where(x => x.Id == i.TypeIdentificationId).FirstOrDefault();
                }
            }

            response.Data = _mapper.Map<IEnumerable<UserDto>>(users);
            response.ReturnMessage = users != null ? ConstantesUsers.GeteUserOk : ConstantesUsers.GetUserFailure;
            return response;
        }

        /// <summary>
        /// Update Password getall users
        /// </summary>
        /// <author>Oscar Julian Rojas</author>
        /// <date>10/07/2021</date>
        /// <returns>IEnumerable users </returns>
        public async Task<Response<UserDto>> UpdatePassword(UserDto userdto, string oldpassword)
        {
            var response = new Response<UserDto>();
            response.GetCorrelation();

            userdto.Password = await this._encriptedPassword.GenerateEncryptedPasswordAsync(userdto.Password);
            var user = this._mapper.Map<User>(userdto);
            var userSelected = await this._userRepository.SelectUpdatePassword(user, oldpassword);
           
            if (userSelected.Password.Equals(userdto.Password))
            {
                var result = _mapper.Map<UserDto>(await _userRepository.UpdatePassword(user));
                response.Data = result;
                response.ReturnMessage = result != null ? ConstantesUsers.GeteUserOk : ConstantesUsers.GetUserFailure;
            }
          
            return response;
        }
    }
}
