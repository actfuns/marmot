using System;
using System.Net.WebSockets;
using System.Threading;
using Marmot.Core.Interfaces;

namespace Marmot.Core.Connector
{
    public class WSChannel : IChannel
    {
        /// <summary>
        /// id
        /// </summary>
        public static int _id;

        /// <summary>
        /// cancellationTokenSource
        /// </summary>
        private readonly CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

        /// <summary>
        /// webSocket
        /// </summary>
        private readonly WebSocket webSocket;

        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// ctx
        /// </summary>
        private readonly HttpListenerWebSocketContext webSocketContext;

        /// <summary>
        /// WSChannel
        /// </summary>
        /// <param name="webSocketContext"></param>
        public WSChannel(HttpListenerWebSocketContext webSocketContext)
        {
            Id = ++_id;
            this.webSocketContext = webSocketContext;
            webSocket = webSocketContext.WebSocket;
        }

        /// <summary>
        /// Send
        /// </summary>
        /// <param name="bytes"></param>
        public async void Send(byte[] bytes)
        {
            await webSocket.SendAsync(new ArraySegment<byte>(bytes, 0, bytes.Length), WebSocketMessageType.Binary, true, cancellationTokenSource.Token);
        }

        ///// <summary>
        ///// recvDDta
        ///// </summary>
        //private async void recvDDta()
        //{
        //    var receiveResult = await this.webSocket.ReceiveAsync(
        //          new Memory<byte>(this.recvStream.GetBuffer(), receiveCount, this.recvStream.Capacity - receiveCount),
        //          cancellationTokenSource.Token);
        //}

        /// <summary>
        /// OnMessage
        /// </summary>
        public event Action<byte[]> OnMessage;
    }
}
