using System.ComponentModel;

namespace Application.Commons
{
    /// <summary>
    /// Helper de parametros sql
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>18/02/2021</date>
    public static class HelpersParameter
    {
        /// <summary>
        /// Constructor builder funcion name database 
        /// </summary>
        /// <param name="squema">Schema de base datos</param>
        /// <param name="name">Nombre procedimiento o funcion de base datos</param>
        /// <author>Oscar Julian Rojas</author>
        /// <date>18/02/2021</date>
        /// <returns>Nombre del procedimiento o funcion con el schema especificado</returns>
        public static string BuilderFunction(EnumSchemas squema, [System.Runtime.CompilerServices.CallerMemberName] string name = null)
        {
            if (!string.IsNullOrEmpty(name))
            {
                return squema switch
                {
                    EnumSchemas.DBO => $"{HelpersEnums.GetEnumDescription(EnumSchemas.DBO)}.{name}",
                    EnumSchemas.SETTING => $"{HelpersEnums.GetEnumDescription(EnumSchemas.SETTING)}.{name}",
                    EnumSchemas.SECURITY => $"{HelpersEnums.GetEnumDescription(EnumSchemas.SECURITY)}.{name}",

                    _ => name,
                };
            }
            else
                return name;
        }

       /// <summary>
       /// Method builder query string for schemma database
       /// </summary>
       /// <param name="squema">specific schemma database</param>
       /// <param name="NameProcedureOrQueryString">QueryString command</param>
       /// <author>Oscar Julian Rojas Garces</author>
       /// <date>20/03/2021</date>
       /// <returns>schemmadatabase + querystring/returns>
        public static string BuilderQueryString(EnumSchemas squema, string NameProcedureOrQueryString)
        {
            if (!string.IsNullOrEmpty(NameProcedureOrQueryString))
            {
                return squema switch
                {
                    EnumSchemas.DBO => $"{HelpersEnums.GetEnumDescription(EnumSchemas.DBO)}.{NameProcedureOrQueryString}",
                    EnumSchemas.SETTING => $"{HelpersEnums.GetEnumDescription(EnumSchemas.SETTING)}.{NameProcedureOrQueryString}",
                    EnumSchemas.SECURITY => $"{HelpersEnums.GetEnumDescription(EnumSchemas.SECURITY)}.{NameProcedureOrQueryString}",

                    _ => NameProcedureOrQueryString,
                };
            }
            else
                return NameProcedureOrQueryString;
        }

        /// <summary>
        /// Enums schemas database 
        /// </summary>
        /// <author>Oscar Julian Rojas</author>
        /// <date>20/03/2021</date>
        public enum EnumSchemas
        {
            [Description("dbo")]
            DBO,

            [Description("setting")]
            SETTING,

            [Description("security")]
            SECURITY
        }
    }
}
