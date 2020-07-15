using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Marmot.Core.Util
{
    public class CJson
    {
        /// <summary>
        /// jsonData
        /// </summary>
        public Dictionary<string, object> Data { get; private set; }

        /// <summary>
        /// settings
        /// </summary>
        private readonly JsonSerializerSettings _settings;

        /// <summary>
        /// 格式化
        /// </summary>
        private readonly Formatting _formatting;

        /// <summary>
        /// 默认构造函数
        /// </summary>
        public CJson()
            : this(Formatting.None, null)
        {

        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="formatting"></param>
        /// <param name="settings"></param>
        public CJson(Formatting formatting, JsonSerializerSettings settings)
        {
            _formatting = formatting;
            _settings = settings;
            Data = new Dictionary<string, object>();
        }

        /// <summary>
        /// 增加数据
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Add(string key, object value)
        {
            if (string.IsNullOrEmpty(key)) return false;

            Data[key] = value;
            return true;
        }

        /// <summary>
        /// 设置数据（存在则修改）
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Set(string key, object value)
        {
            if (string.IsNullOrEmpty(key)) return false;

            if (Data.ContainsKey(key))
                Data[key] = value;
            else
                Data.Add(key, value);

            return true;
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Remove(string key)
        {
            if (string.IsNullOrEmpty(key)) return false;

            return !Data.ContainsKey(key) || Data.Remove(key);
        }

        /// <summary>
        /// 清理数据
        /// </summary>
        /// <returns></returns>
        public void Clear()
        {
            Data.Clear();
        }

        /// <summary>
        /// 转换为json
        /// </summary>
        /// <returns></returns>
        public string ToJson()
        {
            return ToJson(Data, _formatting, _settings);
        }

        /// <summary>
        /// 转换为json
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToJson(object obj)
        {
            return ToJson(obj, Formatting.None, null);
        }

        /// <summary>
        /// 转换为json
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="formatting"></param>
        /// <param name="settings"></param>
        /// <returns></returns>
        public static string ToJson(object obj, Formatting formatting, JsonSerializerSettings settings)
        {
            try
            {
                if (obj == null)
                    return "{}";

                var type = obj.GetType();
                if (type.IsPrimitive || type == typeof(string) || type == typeof(DateTime))
                    return obj.ToString();

                return JsonConvert.SerializeObject(obj, formatting, settings);
            }
            catch
            {
                return "{}";
            }
        }

        /// <summary>
        /// ToObject
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static T ToObject<T>(string input)
        {
            if (string.IsNullOrEmpty(input))
                return default(T);

            return (T)ToObject(input, typeof(T));
        }

        /// <summary>
        /// ToObject
        /// </summary>
        /// <param name="input"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object ToObject(string input, Type type)
        {
            if (string.IsNullOrEmpty(input))
                return null;
            try
            {
                if (type.IsPrimitive || type == typeof(string) || type == typeof(DateTime))
                    return CUtils.Parse(input, type, null);

                return JsonConvert.DeserializeObject(input, type);
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// ToObject
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input"></param>
        /// <returns></returns>
        public static T ToObject<T>(JToken input)
        {
            return ToObject<T>(input == null ? string.Empty : input.ToString());
        }

        /// <summary>
        /// 获得jsonData对象
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static JToken GetJsonData(string input)
        {
            if (string.IsNullOrEmpty(input)) return null;
            try
            {
                return JsonConvert.DeserializeObject<JToken>(input);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 获得json
        /// </summary>
        /// <param name="jsonData"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static JToken GetJsonDataByKey(JToken jsonData, string key)
        {
            if (jsonData == null || !jsonData.HasValues) return null;
            try
            {
                return jsonData.Value<JToken>(key);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 获得json
        /// </summary>
        /// <param name="jsonData"></param>
        /// <param name="key"></param>
        /// <param name="defau"></param>
        /// <returns></returns>
        public static T GetObjectByKey<T>(JToken jsonData, string key, T defau = default(T))
        {
            if (jsonData == null || !jsonData.HasValues)
                return defau;
            try
            {
                JToken jToken = jsonData.Value<JToken>(key);
                return jToken == null ? defau : ToObject<T>(jToken);
            }
            catch
            {
                return defau;
            }
        }
    }
}
