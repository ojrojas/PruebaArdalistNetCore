using Application.Commons;
using Application.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Core
{
    public interface IIdentificationTypeBusinessLogic
    {
        Task<Response<TypeIdentificationDto>> CreateTypeIdentification(TypeIdentificationDto typeIdentificationDto);
        Task<Response<IEnumerable<TypeIdentificationDto>>> GetAll();
    }
}