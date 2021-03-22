using Application.Dtos;
using System.Threading.Tasks;

namespace Main.Tokens
{
    public interface ITokenClaims
    {
        Task<string> GetTokenAsync(UserDto user);
    }
}