using Aura.Core.DependencyInjection.Interfaces;
using Aura.Core.Interfaces;
using Aura.Core.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Aura.Core.DependencyInjection.BuilderExtensions
{
    public static class Core
    {
        public static IAuraBuilder AddTestSuite(this IAuraBuilder builder)
        {
            builder.Services.AddTransient<ITestSuite, TestSuite>();
            return builder;
        }
    }
}