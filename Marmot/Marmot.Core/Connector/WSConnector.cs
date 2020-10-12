using System;
using System.Collections.Generic;
using System.Net;
using System.Net.WebSockets;
using System.Threading.Tasks;
using Marmot.Core.Interfaces;
using Marmot.Core.Util;

namespace Marmot.Core.Connector
{
    /// <summary>
    /// WSConnector
    /// </summary>
    public class WSConnector : IConnector
    {
        /// <summary>
        /// httpListener
        /// </summary>
        private readonly HttpListener httpListener;

        /// <summary>
        /// _channels
        /// </summary>
        public readonly Dictionary<int, WSChannel> channels;

        /// <summary>
        /// WSConnector
        /// </summary>
        public WSConnector()
        {
            channels = new Dictionary<int, WSChannel>();
            httpListener = new HttpListener();
        }

        /// <summary>
        /// Start
        /// </summary>
        /// <returns></returns>
        public async Task Start()
        {
            try
            {
                httpListener.Start();
                while (true)
                {
                    try
                    {
                        HttpListenerContext httpListenerContext = await httpListener.GetContextAsync();
                        HttpListenerWebSocketContext webSocketContext = await httpListenerContext.AcceptWebSocketAsync(null);
                        var channel = new WSChannel(webSocketContext);
                        channels[channel.Id] = channel;

                        //this.OnAccept(channel);
                    }
                    catch (Exception e)
                    {
                        CLog.Error(e);
                    }
                }
            }
            catch (HttpListenerException e)
            {
                if (e.ErrorCode == 5)
                {
                    throw new Exception($"CMD管理员中输入: netsh http add urlacl url=http://*:8080/ user=Everyone", e);
                }
                CLog.Error(e);
            }
            catch (Exception e)
            {
                CLog.Error(e);
            }
        }

        /// <summary>
        /// Stop
        /// </summary>
        /// <param name="force"></param>
        /// <returns></returns>
        public Task Stop(bool force)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Encode
        /// </summary>
        public IEncoder Encode { get; }

        /// <summary>
        /// Decode
        /// </summary>
        public IDecoder Decode { get; }

        /// <summary>
        /// OnConnection
        /// </summary>
        public event Action<IChannel> OnConnection;
    }
}
