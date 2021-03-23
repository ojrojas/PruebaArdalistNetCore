using Application.Commons;
using System.ComponentModel.DataAnnotations;

namespace Application.Dtos
{
    /// <summary>
    /// UserDto context https
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>20/03/2021</date>
    public class UserDto : BaseEntity
    {
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string SurName { get; set; }
        [EmailAddress(ErrorMessage = "El formato de entrada debe ser un correo.")]
        public string Email { get; set; }
        [MaxLength(15, ErrorMessage = "El maximo permitido para el password es de 15 caracteres.")]
        [MinLength( 8, ErrorMessage = "El minimo permitido para el password es de 8 caracteres")]
        public string Password { get; set; }
        public TypeIdentificationDto TypeIdentification { get; set; }
        public string TypeIdentificationId { get; set; }
        public string Identification { get; set; }
    }

    /// <summary>
    /// User command methods update, updatestate, delete
    /// </summary>
    public class UserDtoCommand
    {
        public string OldPassword { get; set; }
        public UserDto UserDto { get; set; }
    }
}
