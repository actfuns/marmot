using System;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;

namespace Marmot.Core.Util
{
    /// <summary>
    /// ManualResetValueTaskSource
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ManualResetValueTaskSource<T> : IValueTaskSource<T>
    {
        /// <summary>
        /// core
        /// </summary>
        private ManualResetValueTaskSourceCore<T> _core;

        /// <summary>
        /// lockObj
        /// </summary>
        private readonly object _lockObj = new object();

        /// <summary>
        /// completed
        /// </summary>
        private bool _completed;

        /// <summary>
        /// ManualResetValueTaskSource
        /// </summary>
        public ManualResetValueTaskSource()
        {
            _core = new ManualResetValueTaskSourceCore<T>();
        }

        /// <summary>
        /// GetResult
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public T GetResult(short token) => _core.GetResult(token);

        /// <summary>
        /// GetStatus
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public ValueTaskSourceStatus GetStatus(short token) => _core.GetStatus(token);

        /// <summary>
        /// OnCompleted
        /// </summary>
        /// <param name="continuation"></param>
        /// <param name="state"></param>
        /// <param name="token"></param>
        /// <param name="flags"></param>
        public void OnCompleted(Action<object> continuation, object state, short token, ValueTaskSourceOnCompletedFlags flags) => _core.OnCompleted(continuation, state, token, flags);

        /// <summary>
        /// SetResult
        /// </summary>
        /// <param name="result"></param>
        public bool SetResult(T result)
        {
            lock (_lockObj)
            {
                if (_completed)
                    return false;

                _completed = true;
            }
            _core.SetResult(result);
            return true;
        }

        /// <summary>
        /// SetException
        /// </summary>
        /// <param name="error"></param>
        public bool SetException(Exception error)
        {
            lock (_lockObj)
            {
                if (_completed)
                    return false;

                _completed = true;
            }
            _core.SetException(error);
            return true;
        }

        /// <summary>
        /// Await
        /// </summary>
        /// <returns></returns>
        public ValueTask<T> Await()
        {
            return new ValueTask<T>(this, _core.Version);
        }
    }
}
