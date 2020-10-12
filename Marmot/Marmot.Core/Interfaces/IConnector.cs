using System;
using System.Threading.Tasks;

namespace Marmot.Core.Interfaces
{
    /// <summary>
    /// IEncoder
    /// </summary>
    public interface IEncoder
    {

    }

    /// <summary>
    /// IDecoder
    /// </summary>
    public interface IDecoder
    {

    }

    /// <summary>
    /// IConnector
    /// </summary>
    public interface IConnector
    {
        /// <summary>
        /// Start
        /// </summary>
        /// <returns></returns>
        Task Start();

        /// <summary>
        /// Stop
        /// </summary>
        /// <param name="force"></param>
        /// <returns></returns>
        Task Stop(bool force);

        /// <summary>
        /// Encode
        /// </summary>
        IEncoder Encode { get; }

        /// <summary>
        /// Decode
        /// </summary>
        IDecoder Decode { get; }

        /// <summary>
        /// OnConnection
        /// </summary>
        event Action<IChannel> OnConnection;
    }
}
