using Aura.Core.Runtime.Interfaces;

namespace Aura.Core.UnitTest.Common
{
    public class Engine
    {
        public static ITestExecutionEngine GetEngine(string reportFileName)
        {
            return new TestExecutionEngine(Driver.GetChromeDriver(), Reporter.GetReporter(reportFileName));
        }
    }
}