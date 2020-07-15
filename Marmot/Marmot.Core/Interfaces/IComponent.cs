using System.Threading.Tasks;

namespace Marmot.Core.Interfaces
{
    /// <summary>
    /// IComponent
    /// </summary>
    public interface IComponent
    {
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// BeforeStart
        /// </summary>
        /// <returns></returns>
        public Task BeforeStart();

        /// <summary>
        /// Start
        /// </summary>
        /// <returns></returns>
        public Task Start();

        /// <summary>
        /// AfterStart
        /// </summary>
        /// <returns></returns>
        public Task AfterStart();

        /// <summary>
        /// stop
        /// </summary>
        /// <returns></returns>
        public Task Stop();
    }
}
