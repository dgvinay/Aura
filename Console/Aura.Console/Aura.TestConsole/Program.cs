using System;
using Aura.Core;
using Aura.Core.AutomationDriver;
using Aura.Core.TestReport.ExtentReports;
using Microsoft.Extensions.DependencyInjection;

namespace Aura.TestConsole
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var services = new ServiceCollection();

            var chromeDriverOptions = new AutomationDriverOptions
            {
            };
            var driver = new DefaultChromeDriver(chromeDriverOptions);
            var reportEngine = new ExtentReportReporter(new ExtentReporterOptions
            {
            });
            var engine = new TestExecutionEngine(driver, reportEngine);
            engine.Fire();
        }
    }
}