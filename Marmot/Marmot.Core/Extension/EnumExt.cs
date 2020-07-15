using System;
using System.ComponentModel;
using System.Linq;
using Marmot.Core.Util;

namespace Marmot.Core.Extension
{
    /// <summary>
    /// EnumExt
    /// </summary>
    public static class EnumExt
    {
        /// <summary>
        /// 获取枚举值
        /// </summary>
        /// <param name="instance">枚举实例</param>
        public static int Value(this Enum instance)
        {
            return (int)Enum.Parse(instance.GetType(), instance.ToString(), true);
        }

        /// <summary>
        /// 获取枚举值
        /// </summary>
        /// <typeparam name="TResult">返回值类型</typeparam>
        /// <param name="instance">枚举实例</param>
        public static TResult Value<TResult>(this Enum instance)
        {
            return CUtils.Parse<TResult>(Value(instance));
        }

        /// <summary>
        /// 获取枚举描述,使用System.ComponentModel.Description特性设置描述
        /// </summary>
        /// <param name="instance">枚举实例</param>
        public static string Description(this Enum instance)
        {
            Type type = instance.GetType();
            // ReSharper disable once AssignNullToNotNullAttribute
            var member = type.GetMember(Enum.GetName(type, instance)).FirstOrDefault();
            if (member == null)
                return string.Empty;

            var info = member.GetCustomAttribute<DescriptionAttribute>();
            return info == null ? string.Empty : info.Description;
        }
    }
}
