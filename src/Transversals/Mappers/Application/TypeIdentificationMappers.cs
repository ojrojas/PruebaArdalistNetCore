using Application.Dtos;
using Application.Entities;
using AutoMapper;

namespace Mappers.Application
{
    /// <summary>
    /// TypeIdentification perfil mappers
    /// </summary>
    public class TypeIdentificationMappers : Profile
    {
        public TypeIdentificationMappers()
        {
            CreateMap<TypeIdentification, TypeIdentificationDto>();
            CreateMap<UserDto, User>();
        }
    }
}
