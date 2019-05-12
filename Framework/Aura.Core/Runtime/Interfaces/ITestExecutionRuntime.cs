using Aura.Core.Interfaces;
using Aura.Core.Models;

namespace Aura.Core.Runtime.Interfaces
{
    public interface ITestExecutionRuntime
    {
        TestExecutionResult Execute(ITestCase testCase);
    }
}