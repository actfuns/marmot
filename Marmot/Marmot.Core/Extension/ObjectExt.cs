using Marmot.Core.Util;

namespace Marmot.Core.Extension
{
    /// <summary>
    /// ObjectExt
    /// </summary>
    public static class ObjectExt
    {
        /// <summary>
        /// 获取字段值
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="name"></param>
        /// <param name="def"></param>
        /// <returns></returns>
        public static T GetFieldValue<T>(this object obj, string name, T def = default(T))
        {
            return CReflex.GetFieldValue(obj, name, def);
        }

        /// <summary>
        /// 获取属性值
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="name"></param>
        /// <param name="def"></param>
        /// <returns></returns>
        public static T GetPropValue<T>(this object obj, string name, T def = default(T))
        {
            return CReflex.GetPropValue(obj, name, def);
        }

        /// <summary>
        /// 安全获取值，当值为null时，不会抛出异常
        /// </summary>
        /// <param name="value">可空值</param>
        public static T SafeValue<T>(this T? value) where T : struct
        {
            return value ?? default(T);
        }

        /// <summary>
        /// 安全转换为字符串，去除两端空格，当值为null时返回""
        /// </summary>
        /// <param name="input">输入值</param>
        public static string SafeString(this object input)
        {
            return input == null ? string.Empty : input.ToString().Trim();
        }
    }
}
