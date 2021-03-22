﻿using System.ComponentModel;

namespace Application.Data
{
    /// <summary>
    /// Anotation parameters query string
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>20/03/2021</date>
    public enum EnumUserParameters
    {
        [Description("@@Id")]
        ID,

        [Description("@@Name")]
        NAME,

        [Description("@@MiddleName")]
        MIDDLE_NAME,

        [Description("@@SurName")]
        SUR_NAME,

        [Description("@@LastName")]
        LAST_NAME,

        [Description("@@ModifiedOn")]
        MODIFIED_ON,

        [Description("@@CreatedOn")]
        CREATED_ON,

        [Description("@@CreatedBy")]
        CREATED_BY,

        [Description("@@ModifiedBy")]
        MODIFIED_BY,

        [Description("@@UserName")]
        USER_NAME,

        [Description("@@Password")]
        PASSWORD,

        [Description("@@State")]
        STATE
    }
}
