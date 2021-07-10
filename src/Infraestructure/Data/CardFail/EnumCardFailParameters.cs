using System.ComponentModel;

namespace Application.Data
{
    public enum EnumCardFailParameters
    {
        /// <summary>
        /// Enum parameters querys dapper
        /// </summary>
        [Description("@@Id")]
        ID,

        [Description("@@Quantities")]
        Quantities,

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
