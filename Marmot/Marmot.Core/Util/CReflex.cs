using System;
using System.Reflection;

namespace Marmot.Core.Util
{
    /// <summary>
    /// CReflex
    /// </summary>
    public class CReflex
    {
        /// <summary>
        /// 获取属性值
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="name"></param>
        /// <param name="def"></param>
        /// <returns></returns>
        public static T GetPropValue<T>(object obj, string name, T def = default(T))
        {
            return CUtils.Parse(GetPropValue(obj, name), def);
        }

        /// <summary>
        /// GetPropValue
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static object GetPropValue(object obj, string name)
        {
            if (obj == null || string.IsNullOrEmpty(name))
                return null;
            try
            {
                Type type = obj.GetType();
                PropertyInfo prop = type.GetProperty(name);
                return prop == null ? null : prop.GetValue(obj, null);
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// GetFieldValue
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="name"></param>
        /// <param name="def"></param>
        /// <returns></returns>
        public static T GetFieldValue<T>(object obj, string name, T def = default(T))
        {
            return CUtils.Parse(GetFieldValue(obj, name), def);
        }

        /// <summary>
        /// GetFieldValue
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static object GetFieldValue(object obj, string name)
        {
            if (obj == null || string.IsNullOrEmpty(name))
                return null;
            try
            {
                Type type = obj.GetType();
                FieldInfo field = type.GetField(name);
                return field == null ? null : field.GetValue(obj);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
