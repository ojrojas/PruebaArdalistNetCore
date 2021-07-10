using Application.Commons;
using Application.Dtos;
using Application.Entities;
using Application.Main;
using Application.Repositories;
using AutoMapper;
using Main.Tokens;
using System.Threading.Tasks;

namespace Application.Core
{
    public class LoginBusinessLogic : ILoginBusinessLogic
    {
        private readonly ITokenClaims _tokenClaims;
        private readonly IEncryptedPassword _encriptedPassword;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public LoginBusinessLogic(ITokenClaims tokenClaims, IEncryptedPassword encriptedPassword, IMapper mapper, IUserRepository userRepository)
        {
            _tokenClaims = tokenClaims;
            _encriptedPassword = encriptedPassword;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<Response<string>> LoginUser(LoginDto logindto)
        {
            var response = new Response<string>();
            response.GetCorrelation();
            logindto.Password = await _encriptedPassword.GenerateEncryptedPasswordAsync(logindto.Password);
            var user = _mapper.Map<User>(logindto);
            var found = await _userRepository.SelectLoginUser(user);
            var result = await _tokenClaims.GetTokenAsync(this._mapper.Map<UserDto>(found));
            response.Data = result;
            response.ReturnMessage = result != null ? "Login exitoso" : "login fallido";

            return response;
        }
    }
}
