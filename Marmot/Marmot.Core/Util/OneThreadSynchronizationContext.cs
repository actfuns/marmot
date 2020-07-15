using System;
using System.Collections.Concurrent;
using System.Threading;

namespace Marmot.Core.Util
{
    /// <summary>
    /// OneThreadSynchronizationContext
    /// </summary>
    public class OneThreadSynchronizationContext : SynchronizationContext
    {
        /// <summary>
        /// Instance
        /// </summary>
        public static OneThreadSynchronizationContext Instance { get; } = new OneThreadSynchronizationContext();

        /// <summary>
        /// mainThreadId
        /// </summary>
        private readonly int mainThreadId;

        /// <summary>
        /// 线程同步队列,发送接收socket回调都放到该队列,由poll线程统一执行
        /// </summary>
        private readonly ConcurrentQueue<Action> queue = new ConcurrentQueue<Action>();

        /// <summary>
        /// status
        /// </summary>
        private bool status;

        /// <summary>
        /// 等待变量
        /// </summary>
        private readonly EventWaitHandle waitHandle;

        /// <summary>
        /// OneThreadSynchronizationContext
        /// </summary>
        public OneThreadSynchronizationContext() 
        {
            waitHandle = new EventWaitHandle(false, EventResetMode.AutoReset);
            mainThreadId = Thread.CurrentThread.ManagedThreadId; 
        }

        /// <summary>
        /// Start
        /// </summary>
        public void Start()
        {
            status = true;
            Action action;
            while (status) 
            {
                while (queue.TryDequeue(out action))
                {
                    action();
                }
                waitHandle.WaitOne();
            }
        }

        /// <summary>
        /// Stop
        /// </summary>
        public void Stop()
        {
            waitHandle.Set();
            status = false;
        }

        /// <summary>
        /// Post
        /// </summary>
        /// <param name="callback"></param>
        /// <param name="state"></param>
        public override void Post(SendOrPostCallback callback, object state)
        {
            if (Thread.CurrentThread.ManagedThreadId == mainThreadId)
            {
                callback(state);
                return;
            }
            queue.Enqueue(() => { callback(state);});
            waitHandle.Set();
        }
    }
}
