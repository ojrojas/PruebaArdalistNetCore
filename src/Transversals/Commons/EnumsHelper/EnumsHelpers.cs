using System;
using System.ComponentModel;
using System.Reflection;

namespace Application.Commons
{
    /// <summary>
    /// Extensions Enums Helpers
    /// </summary>
    /// <author>Oscar Julian Rojas</author>
    /// <date>10/07/2021</date>
    public static class HelpersEnums
    {
        /// <summary>
        /// Descriptions Enumerables
        /// </summary>
        /// <param name="enumValue">Value enum</param>
        /// <author>Oscar Julian Rojas</author>
        /// <date>10/07/2021</date>
        /// <returns>Description value enum</returns>
        public static string GetEnumDescription(Enum enumValue)
        {
            FieldInfo fi = enumValue.GetType().GetField(enumValue.ToString());

            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
                return attributes[0].Description;
            else
                return enumValue.ToString();
        }
    }
}
