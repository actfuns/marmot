using System;

namespace Marmot.Core.Interfaces
{
    /// <summary>
    /// IChannel
    /// </summary>
    public interface IChannel
    {
        /// <summary>
        /// Send
        /// </summary>
        public void Send(byte[] bytes);

        /// <summary>
        /// OnMessage
        /// </summary>
        public event Action<byte[]> OnMessage;
    }
}
