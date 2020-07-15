using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using Marmot.Core.Extension;
using Marmot.Core.Extension;
using Newtonsoft.Json;

namespace Marmot.Core.Util
{
    /// <summary>
    /// CUtils
    /// </summary>
    public class CUtils
    {
        #region 类型转换
        /// <summary>
        /// ToFixed
        /// </summary>
        /// <param name="input"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static double ToFixed(double input, int length)
        {
            if (length <= 0)
                return (long)input;

            long baseNums = (long)Math.Pow(10, length);
            return Math.Round((long)(baseNums * input) * 1.0 / baseNums, length);
        }

        /// <summary>
        /// Parse
        /// </summary>
        /// <param name="input"></param>
        /// <param name="type"></param>
        /// <param name="defau"></param>
        /// <returns></returns>
        public static object Parse(object input, Type type, object defau)
        {
            if (input == null)
                return defau;

            var typeName = type.Name.ToLower();
            try
            {
                if (typeName == "string")
                    return input.ToString();

                if (typeName == "guid")
                    return new Guid(input.ToString());

                if (type.IsEnum)
                    return Enum.Parse(type, input.SafeString(), true);

                if (input is IConvertible)
                    return Convert.ChangeType(input, type);

                return input;
            }
            catch
            {
                return defau;
            }
        }

        /// <summary>
        /// 通用泛型转换
        /// </summary>
        /// <typeparam name="T">目标类型</typeparam>
        /// <param name="input">输入值</param>
        /// <param name="defau">默认值</param>
        public static T Parse<T>(object input, T defau = default(T))
        {
            if (input == null)
                return defau;

            return (T)Parse(input, typeof(T), defau);
        }

        /// <summary>
        /// UrlDecode
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string UrlDecode(string input)
        {
            return string.IsNullOrEmpty(input) ? string.Empty : HttpUtility.UrlDecode(input);
        }

        /// <summary>
        /// UrlEncode
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string UrlEncode(string input)
        {
            return string.IsNullOrEmpty(input) ? string.Empty : HttpUtility.UrlEncode(input);
        }

        /// <summary>
        /// UrlEncodeToUpper(转义字符大写)
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string UrlEncodeToUpper(string input)
        {
            StringBuilder builder = new StringBuilder();
            foreach (var c in input)
            {
                string t = c.ToString();
                switch (t)
                {
                    case "'":
                        t = "%27";
                        builder.Append(t);
                        break;

                    case " ":
                        t = "%20";
                        builder.Append(t);
                        break;

                    case "(":
                        t = "%28";
                        builder.Append(t);
                        break;

                    case ")":
                        t = "%29";
                        builder.Append(t);
                        break;

                    case "!":
                        t = "%21";
                        builder.Append(t);
                        break;

                    case "*":
                        t = "%2A";
                        builder.Append(t);
                        break;

                    default:
                        string k = HttpUtility.UrlEncode(t, Encoding.UTF8);
                        builder.Append(t == k ? t : k.ToUpper());
                        break;
                }
            }
            return builder.ToString();
        }

        /// <summary>
        /// ToDictionary(属性取值)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static Dictionary<string, string> ToDictionary<T>(T obj)
            where T : class
        {
            if (obj == null)
                return null;

            PropertyInfo[] propertys = obj.GetType().GetProperties();
            Dictionary<string, string> dic = new Dictionary<string, string>();
            try
            {
                foreach (var property in propertys)
                {
                    object value = property.GetValue(obj, null);
                    var ptype = property.PropertyType;
                    string svalue = string.Empty;
                    if (value != null)
                    {
                        string pname = ptype.Name.ToLower();
                        if (ptype.IsPrimitive || pname == "string" || pname == "datetime" || pname == "decimal")
                            svalue = value.ToString();
                        else if (ptype.IsEnum)
                            svalue = value.ToString();
                        else
                            svalue = JsonConvert.SerializeObject(value);
                    }
                    dic.Add(property.Name, svalue);
                }
                return dic;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// ToObject(属性赋值)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dic"></param>
        /// <returns></returns>
        public static T ToObject<T>(Dictionary<string, string> dic)
              where T : class, new()
        {
            if (dic == null || dic.Count <= 0)
                return null;

            T obj = new T();
            Type type = obj.GetType();
            try
            {
                foreach (var pair in dic)
                {
                    PropertyInfo property = type.GetProperty(pair.Key);
                    if (property == null)
                        continue;

                    var ptype = property.PropertyType;
                    object value;
                    string pname = ptype.Name.ToLower();
                    if (ptype.IsPrimitive || pname == "string" || pname == "datetime" || pname == "decimal")
                        value = Convert.ChangeType(pair.Value, ptype);
                    else if (ptype.IsEnum)
                        value = Enum.Parse(ptype, pair.Value, true);
                    else
                        value = JsonConvert.DeserializeObject(pair.Value, ptype);
                    property.SetValue(obj, value, null);
                }
                return obj;
            }
            catch (Exception ex)
            {
                CLog.Error(ex);
                return null;
            }
        }

        /// <summary>
        /// 去除空格
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        public static void Trim<T>(T obj)
            where T : class
        {
            if (obj == null) return;
            PropertyInfo[] propertyInfos = obj.GetType().GetProperties();
            try
            {
                foreach (var propertyInfo in propertyInfos)
                {
                    Type fileldType = propertyInfo.PropertyType;
                    if (fileldType == typeof(string))
                    {
                        string str = propertyInfo.GetValue(obj, null) as string ?? string.Empty;
                        propertyInfo.SetValue(obj, str.Trim(), null);
                    }
                }
            }
            catch
            {
                // ignored
            }
        }
        #endregion

        #region 随机数
        /// <summary>
        /// _random 多线程公用实例有问题 使用线程变量修复
        /// </summary>
        [ThreadStatic]
        private static Random _random;

        /// <summary>
        /// getRandom
        /// </summary>
        /// <returns></returns>
        private static Random getRandom()
        {
            if (_random == null)
                _random = GetRandom();

            return _random;
        }

        /// <summary>
        /// FNV 散列
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private static int FNVHash(string data)
        {
            const int p = 16777619;
            long lg = 2166136261L;
            int hash = (int)lg;
            hash = data.Aggregate(hash, (current, t) => (current ^ t) * p);
            hash += hash << 13;
            hash ^= hash >> 7;
            hash += hash << 3;
            hash ^= hash >> 17;
            hash += hash << 5;
            return hash;
        }

        /// <summary>
        /// 获得一个随机对象
        /// </summary>
        /// <returns></returns>
        public static Random GetRandom()
        {
            //传入时间种子
            int seek = FNVHash(Guid.NewGuid().GetHashCode().ToString());
            return new Random(seek);
        }

        /// <summary>
        /// GetRandomInt
        /// </summary>
        /// <param name="minVal"></param>
        /// <param name="maxVal"></param>
        /// <returns></returns>
        public static int GetRandomInt(int minVal, int maxVal)
        {
            return getRandom().Next(minVal, maxVal);
        }

        /// <summary>
        /// GetRandomDouble
        /// </summary>
        /// <param name="minVal"></param>
        /// <param name="maxVal"></param>
        /// <returns></returns>
        public static double GetRandomDouble(double minVal, double maxVal)
        {
            return minVal + (maxVal - minVal) * getRandom().NextDouble();
        }

        /// <summary>
        /// 获得随机数(性能不好,效果好)
        /// </summary>
        /// <param name="minVal"></param>
        /// <param name="maxVal"></param>
        /// <returns></returns>
        public static int GetRandom(int minVal, int maxVal)
        {
            int diff = Math.Abs(maxVal - minVal);
            minVal = minVal > maxVal ? maxVal : minVal;

            byte[] randomBytes = new byte[8];
            RNGCryptoServiceProvider rngServiceProvider = new RNGCryptoServiceProvider();
            rngServiceProvider.GetBytes(randomBytes);
            return minVal + (int)(diff * Math.Abs(BitConverter.ToInt32(randomBytes, 0) * 1.0 / int.MaxValue));
        }

        /// <summary>
        /// 获得随机列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="lstIn">列表</param>
        /// <param name="nLen">数量</param>
        /// <returns></returns>
        public static List<T> GetRandList<T>(List<T> lstIn, int nLen)
        {
            if (lstIn == null || nLen <= 0)
                return null;

            if (lstIn.Count <= nLen)
                return lstIn.ToList();

            List<T> lstRand = new List<T>();
            Random rand = GetRandom();
            int nSize = lstIn.Count;
            for (int i = 0; i < lstIn.Count && nLen > 0; i++)
            {
                float fRand = (float)rand.Next() / int.MaxValue;
                if (fRand <= (float)nLen / nSize)
                {
                    lstRand.Add(lstIn[i]);
                    nLen--;
                }
                nSize--;
            }
            return lstRand;
        }

        /// <summary>
        /// GetRandomItemByProb
        /// </summary>
        /// <param name="data"></param>
        /// <param name="defau"></param>
        /// <returns></returns>
        public static T GetRandomItemByProb<T>(Dictionary<T, double> data, T defau = default(T))
        {
            if (data == null || data.Count <= 0)
                return defau;

            double sum = data.Sum(c => c.Value);
            double rnum = GetRandomDouble(0, sum);
            double score = 0;
            foreach (var model in data)
            {
                score += model.Value;
                if (rnum < score)
                    return model.Key;
            }
            return defau;
        }

        #endregion

        #region 其他
        /// <summary>
        /// 是否为手机号码
        /// </summary>
        /// <param name="mobile"></param>
        /// <returns></returns>
        public static bool IsMobile(string mobile)
        {
            string reg = @"^(13[0-9]|15[0-9]|14[0-9]|17[0-9]|18[0-9])\d{8}$";
            if (Regex.IsMatch(mobile, reg))
                return true;
            return false;
        }

        /// <summary>
        /// GetNewGuid
        /// </summary>
        /// <returns></returns>
        public static string GetNewGuid()
        {
            return Guid.NewGuid().ToString("N");
        }
        #endregion

        #region 数组
        /// <summary>
        /// 列表是否有数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static bool HasData<T>(List<T> list)
        {
            if (list != null && list.Count > 0) return true;
            return false;
        }

        /// <summary>
        /// 哈希是否有数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="V"></typeparam>
        /// <param name="dic"></param>
        /// <returns></returns>
        public static bool HasData<T, V>(IDictionary<T, V> dic)
        {
            if (dic != null && dic.Count > 0) return true;
            return false;
        }
        #endregion
    }
}
