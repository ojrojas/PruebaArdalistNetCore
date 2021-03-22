using Application.Dtos;
using System.Threading.Tasks;

namespace Application.Core
{
    public interface ILoginBusinessLogic
    {
        Task<string> LoginUser(LoginDto logindto);
    }
}