using System;
using System.Threading.Tasks;
using Marmot.Core.Interfaces;

namespace Marmot.Core.Components
{
    /// <summary>
    /// ConnectorComponentOptions
    /// </summary>
    public interface ConnectorComponentOptions
    {
        /// <summary>
        /// Encode
        /// </summary>
        IEncoder Encode { get; }

        /// <summary>
        /// decode
        /// </summary>
        IDecoder Decode { get; }
    }

    /// <summary>
    /// ConnectorComponent
    /// </summary>
    public class ConnectorComponent : IComponent
    {
        /// <summary>
        /// app
        /// </summary>
        private Application app;

        /// <summary>
        /// connector
        /// </summary>
        private IConnector connector;

        /// <summary>
        /// encode
        /// </summary>
        private IEncoder encode;

        /// <summary>
        /// decode
        /// </summary>
        private IDecoder decode;

        /// <summary>
        /// ConnectorComponent
        /// </summary>
        /// <param name="app"></param>
        /// <param name="opts"></param>
        public ConnectorComponent(Application app, ConnectorComponentOptions opts)
        {
            this.app = app;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Task BeforeStart()
        {
            throw new NotImplementedException();
        }

        public Task Start()
        {
            throw new NotImplementedException();
        }

        public Task AfterStart()
        {
            throw new NotImplementedException();
        }

        public Task AfterStartAll()
        {
            throw new NotImplementedException();
        }

        public Task Stop()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        /// <param name="opts"></param>
        //private getConnector(Application app, ConnectorComponentOptions opts)
        //{
        //    var connector = opts.connector;
        //    if (!connector)
        //    {
        //        return getDefaultConnector(app, opts);
        //    }

        //    if (typeof connector != = 'function')
        //    {
        //        return connector;
        //    }

        //    let curServer = app.getCurServer();
        //    return new connector(curServer.clientPort, curServer.host, opts);
        //}

        //        private getDefaultConnector(Application app, ConnectorComponentOptions opts)
        //        {

        //            let getDefaultConnector = function(app: Application, opts: SIOConnectorOptions) {
        //    let curServer = app.getCurServer();
        //        return new SIOConnector(curServer.clientPort, curServer.host, opts);
        //    };
        //}
    }
}
