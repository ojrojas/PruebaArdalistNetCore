using Application.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface ITypeIdentificationRepository
    {
        Task<TypeIdentification> CreateTypeIdentification(TypeIdentification typeIdentificacion);
        Task<IEnumerable<TypeIdentification>> GetAll();
    }
}