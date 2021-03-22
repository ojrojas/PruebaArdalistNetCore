using Application.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Core
{
    public interface IIdentificationTypeBusinessLogic
    {
        Task<IEnumerable<TypeIdentificationDto>> GetAll();
    }
}