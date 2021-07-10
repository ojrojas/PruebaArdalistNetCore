using Application.Commons;
using Application.Commons.Constants;
using Application.Dtos;
using Application.Entities;
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
        /// <date>10/07/2021</date>
        /// <returns>IEnumerable type identifications </returns>
        public async Task<Response<IEnumerable<TypeIdentificationDto>>> GetAll()
        {
            var response = new Response<IEnumerable<TypeIdentificationDto>>();
            response.GetCorrelation();
            var result = this._mapper.Map<IEnumerable<TypeIdentificationDto>>(await this._typeIdentificationRepository.GetAll());

            response.Data = result;
            response.ReturnMessage = result != null ?
                ConstantsTypeIdentificacion.TypeIdentificacionGetOk : ConstantsTypeIdentificacion.TypeIdentificacionGetFailure;

            return response;
        }

        public async Task<Response<TypeIdentificationDto>> CreateTypeIdentification(TypeIdentificationDto typeIdentificationDto)
        {
            var response = new Response<TypeIdentificationDto>();
            response.GetCorrelation();
            var typeIdentification = _mapper.Map<TypeIdentification>(typeIdentificationDto);
            var result = _mapper.Map<TypeIdentificationDto>(await _typeIdentificationRepository.CreateTypeIdentification(typeIdentification));

            response.Data = result;
            response.ReturnMessage = result != null ? ConstantsTypeIdentificacion.TypeIdentificacionOk : ConstantsTypeIdentificacion.TypeIdentificacionFailure;

            return response;
        }
    }
}
