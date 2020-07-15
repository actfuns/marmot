using Marmot.Core.Util;
using System.Collections.Generic;
using System.Threading;

namespace Marmot.Core
{
    /// <summary>
    /// Application
    /// </summary>
    public class Application
    {
        /// <summary>
        /// setting
        /// </summary>
        private Dictionary<string, object> setting;

        /// <summary>
        /// Application
        /// </summary>
        public Application() 
        {
            setting = new Dictionary<string, object>();
            SynchronizationContext.SetSynchronizationContext(OneThreadSynchronizationContext.Instance);
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public T Get<T>(string key) 
        {
            return (T)setting[key];
        }

        /// <summary>
        /// Set
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="val"></param>
        public void Set<T>(string key, T val) {
            setting.Add(key, val);
        }

        /// <summary>
        /// Start
        /// </summary>
        public void Start() 
        {
            OneThreadSynchronizationContext.Instance.Start();
        }
    }
}
