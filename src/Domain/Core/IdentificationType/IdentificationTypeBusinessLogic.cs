using Application.Dtos;
using Application.Repositories;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Core
{
    /// <summary>
    /// Logica Negocio Type Identification
    /// </summary>
    public class IdentificationTypeBusinessLogic : IIdentificationTypeBusinessLogic
    {

        private readonly IMapper _mapper;
        private readonly ITypeIdentificationRepository _typeIdentificationRepository;

        public IdentificationTypeBusinessLogic(IMapper mapper, ITypeIdentificationRepository typeIdentificationRepository)
        {
            _mapper = mapper;
            _typeIdentificationRepository = typeIdentificationRepository;
        }

        /// <summary>
        /// Method getall typeidentifications
        /// </summary>
        /// <author>Oscar Julian Rojas</author>
        /// <date>20/03/2021</date>
        /// <returns>IEnumerable type identifications </returns>
        public async Task<IEnumerable<TypeIdentificationDto>> GetAll()
        {
            return this._mapper.Map<IEnumerable<TypeIdentificationDto>>(await this._typeIdentificationRepository.GetAll());
        }
    }
}
