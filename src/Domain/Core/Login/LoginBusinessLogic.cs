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

        public async Task<string> LoginUser(LoginDto logindto)
        {
            logindto.Password = await this._encriptedPassword.GenerateEncryptedPasswordAsync(logindto.Password);
            var user = this._mapper.Map<User>(logindto);
            var found = await this._userRepository.SelectLoginUser(user);
            if (found != null) return await this._tokenClaims.GetTokenAsync(this._mapper.Map<UserDto>(found));
            return null;
        }
    }
}
