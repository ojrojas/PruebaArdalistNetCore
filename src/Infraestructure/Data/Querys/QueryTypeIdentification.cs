using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Data
{
    public static class QueryTypeIdentification
    {
        public const string GetAllTypeIdentification = "SELECT Id, Description, CreatedOn, CreatedBy, ModifiedOn, ModifiedBy, State FROM TypeIdentifications";
    }
}
