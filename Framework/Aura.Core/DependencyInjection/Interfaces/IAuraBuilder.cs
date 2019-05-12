using Microsoft.Extensions.DependencyInjection;

namespace Aura.Core.DependencyInjection.Interfaces
{
    /// <summary>
    /// Aura builder interface.
    /// </summary>
    public interface IAuraBuilder
    {
        /// <summary>
        /// Gets the services.
        /// </summary>
        /// <value>The services.</value>
        IServiceCollection Services { get; }
    }
}