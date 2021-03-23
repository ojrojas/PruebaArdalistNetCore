using Application.Commons;
using System.ComponentModel.DataAnnotations;

namespace Application.Entities
{
    /// <summary>
    /// User Entity
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>20/03/2021</date>
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string SurName { get; set; }
        [EmailAddress(ErrorMessage = "El formato de entrada debe ser un correo.")]
        public string Email { get; set; }
        [MaxLength(15, ErrorMessage = "El maximo permitido para el password es de 15 caracteres.")]
        [MinLength(8, ErrorMessage = "El minimo permitido para el password es de 8 caracteres")]
        public string Password { get; set; }
        public TypeIdentification TypeIdentification { get; set; }
        public string TypeIdentificationId { get; set; }
        public string Identification { get; set; }
    }
}
