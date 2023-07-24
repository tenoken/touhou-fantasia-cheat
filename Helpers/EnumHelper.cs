using System.ComponentModel;

namespace TouhouFantasiaCheat.Helpers
{
    /// <summary>
    /// Helper for enums.
    /// </summary>
    public static class EnumHelper
    {
        /// <summary>
        /// Get description from enum stucture if it has description attribute.
        /// </summary>
        /// <param name="description"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T GetValueFromDescription<T>(string description) where T : Enum
        {
            foreach (var field in typeof(T).GetFields())
            {
                if (Attribute.GetCustomAttribute(field,
                typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
                {
                    if (attribute.Description == description)
                        return (T)field.GetValue(null);
                }
                else
                {
                    if (field.Name == description)
                        return (T)field.GetValue(null);
                }
            }

            throw new ArgumentException("Cheat not found.", nameof(description));
        }
    }
}