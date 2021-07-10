using System;

namespace Application.Commons
{
    /// <summary>
    /// BaseEntity Class Entity
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>10/07/2021</date>
    public class BaseEntity
    {
        public string Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public bool State { get; set; }
    }
}
