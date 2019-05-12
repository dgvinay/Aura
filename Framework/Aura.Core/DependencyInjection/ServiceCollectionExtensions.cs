using Aura.Core.DependencyInjection.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Aura.Core.DependencyInjection
{
    /// <summary>
    /// DI extension methods for adding Aura
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the aura builder.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns></returns>
        public static IAuraBuilder AddAuraBuilder(this IServiceCollection services)
        {
            return new AuraBuilder(services);
        }

        /// <summary>
        /// Adds the aura.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns></returns>
        public static IAuraBuilder AddAura(this IServiceCollection services)
        {
            var builder = services.AddAuraBuilder();

            return builder;
        }
    }
}