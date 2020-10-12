using System.Threading.Tasks;

namespace Marmot.Core.Interfaces
{
    /// <summary>
    /// IComponent
    /// </summary>
    public interface IComponent
    {
        /// <summary>
        /// BeforeStart
        /// </summary>
        /// <returns></returns>
        Task BeforeStart();

        /// <summary>
        /// Start
        /// </summary>
        /// <returns></returns>
        Task Start();

        /// <summary>
        /// AfterStart
        /// </summary>
        /// <returns></returns>
        Task AfterStart();

        /// <summary>
        /// AfterStartAll
        /// </summary>
        /// <returns></returns>
        Task AfterStartAll();

        /// <summary>
        /// Stop
        /// </summary>
        /// <returns></returns>
        Task Stop();
    }
}
