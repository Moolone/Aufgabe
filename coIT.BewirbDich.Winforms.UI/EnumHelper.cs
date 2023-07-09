using coIT.BewirbDich.Winforms.Domain;
using System.ComponentModel;
using System.Reflection;

namespace coIT.BewirbDich.Winforms.UI
{
    /// <summary>
    /// Hilfsklasse für Enums.
    /// </summary>
    internal static class EnumHelper
    {
        /// <summary>
        /// Gibt die im <see cref="DescriptionAttribute"/> definierte Beschreibung des Enums zurück.
        /// </summary>
        /// <typeparam name="T">Das Enum.</typeparam>
        /// <param name="enumValue">Der Wert des Enums.</param>
        /// <returns>Die gefundene Beschreibung, oder den Enum-Wert as String.</returns>
        public static string GetDescription<T>(this T enumValue) where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
                return null;

            var valueString = enumValue.ToString();
            var fieldInfo = enumValue.GetType().GetField(valueString);

            return GetDescriptionAttributeValue(fieldInfo) ?? valueString; ;
        }

        /// <summary>
        /// Liefert zu der Beschreibung des Enums <see cref="T"/> den entsprechenden Wert.
        /// </summary>
        /// <typeparam name="T">Typ des Enums.</typeparam>
        /// <param name="description">Die Beschreibung</param>
        /// <returns>Den gesuchten Wert, oder null.</returns>
        public static T? GetValueByDescription<T>(this string description) where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
                return null;

            foreach (var info in typeof(CalculationType).GetFields())
            {               
                if (GetDescriptionAttributeValue(info) == description)
                    return (T?)info.GetValue(null);                
            }

            return null;
        }

        /// <summary>
        /// Liest das <see cref="DescriptionAttribute"/> eines Felds aus und gibt den Wert zurück.
        /// </summary>
        /// <param name="info">Das Feld.</param>
        /// <returns>Die Beschreibung oder null.</returns>
        private static string? GetDescriptionAttributeValue(FieldInfo info)
        {
            var attrs = info?.GetCustomAttributes(typeof(DescriptionAttribute), true);
            if (attrs != null && attrs.Length > 0)
            {
                return ((DescriptionAttribute)attrs[0]).Description;
            }
            return null;
        }
        
    }
}
