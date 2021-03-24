using Application.Dtos;
using Application.Entities;
using AutoMapper;

namespace Mappers.Application
{
    public class UserMappersProfile : Profile
    {
        /// <summary>
        /// Mappers Application domain
        /// </summary>
        /// <author>Oscar Julian Rojas</author>
        /// <date>20/03/2021</date>
        public UserMappersProfile()
        {
            /// User, UserDto
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();

            /// TypeIdentification
            CreateMap<TypeIdentification, TypeIdentificationDto>();
            CreateMap<TypeIdentificationDto, TypeIdentification>();



            CreateMap<LoginDto, User>();
        }
    }
}
