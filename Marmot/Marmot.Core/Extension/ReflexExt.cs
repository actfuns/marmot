using System;
using System.Linq;
using System.Reflection;

namespace Marmot.Core.Extension
{
    public static class ReflexExt
    {

        /// <summary>
        /// GetCustomAttribute
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Attribute GetCustomAttribute(this ICustomAttributeProvider provider, Type type)
        {
            if (provider == null)
                return null;

            return provider.GetCustomAttributes(type, true).FirstOrDefault() as Attribute;
        }

        /// <summary>
        /// GetCustomAttribute
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="provider"></param>
        /// <returns></returns>
        public static T GetCustomAttribute<T>(this ICustomAttributeProvider provider)
            where T : Attribute
        {
            if (provider == null)
                return null;

            return (T)provider.GetCustomAttribute(typeof(T));
        }
    }
}
