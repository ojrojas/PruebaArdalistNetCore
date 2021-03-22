using System.Threading.Tasks;

namespace Application.Main
{
    public interface IEncryptedPassword
    {
        Task<string> GenerateEncryptedPasswordAsync(string password);
    }
}