using Application.Commons;
using Application.Dtos;
using System.Threading.Tasks;

namespace Application.Core
{
    public interface ILoginBusinessLogic
    {
        Task<Response<string>> LoginUser(LoginDto logindto);
    }
}