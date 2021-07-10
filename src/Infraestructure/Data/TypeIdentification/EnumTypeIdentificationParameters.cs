using System.ComponentModel;

namespace Application.Data
{
    /// <summary>
    /// Enum parameters querys dapper
    /// </summary>
    public enum EnumTypeIdentificationParameters
    {
        [Description("@@Id")]
        ID,

        [Description("@@Description")]
        Description,

        [Description("@@ModifiedOn")]
        MODIFIED_ON,

        [Description("@@CreatedOn")]
        CREATED_ON,

        [Description("@@CreatedBy")]
        CREATED_BY,

        [Description("@@ModifiedBy")]
        MODIFIED_BY,

        [Description("@@State")]
        STATE,
    }
}
