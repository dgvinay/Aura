using System;
using Aura.Core.DependencyInjection.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Aura.Core.DependencyInjection
{
    /// <summary>
    /// </summary>
    /// <seealso cref="Aura.Core.DependencyInjection.Interfaces.IAuraBuilder" />
    public class AuraBuilder : IAuraBuilder
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuraBuilder" /> class.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <exception cref="System.ArgumentNullException">services</exception>
        public AuraBuilder(IServiceCollection services)
        {
            Services = services ?? throw new ArgumentNullException(nameof(services));
        }

        /// <summary>
        /// Gets the services.
        /// </summary>
        /// <value>The services.</value>
        public IServiceCollection Services { get; }
    }
}