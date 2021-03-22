using Application.Commons;

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
        public string Email { get; set; }
        public string Password { get; set; }
        public string IdentificationType { get; set; }
        public string Identification { get; set; }
    }
}
