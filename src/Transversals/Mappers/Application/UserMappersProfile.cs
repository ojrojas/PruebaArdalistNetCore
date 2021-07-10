using Application.Dtos;
using Application.Entities;
using AutoMapper;

namespace Mappers.Application
{
    public class ApplicationMappersProfile : Profile
    {
        /// <summary>
        /// Mappers Application domain
        /// </summary>
        /// <author>Oscar Julian Rojas</author>
        /// <date>10/07/2021</date>
        public ApplicationMappersProfile()
        {
            /// User, UserDto
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();

            /// TypeIdentification
            CreateMap<TypeIdentification, TypeIdentificationDto>();
            CreateMap<TypeIdentificationDto, TypeIdentification>();
            CreateMap<CardFailDto, CardFail>();



            CreateMap<LoginDto, User>();
        }
    }
}
