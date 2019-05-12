using Aura.Core.Enums;

namespace Aura.Core.Models
{
    /// <summary>
    /// </summary>
    public class TestExecutionResult
    {
        public TestExecutionStatus Status { get; set; }

        public string TestCaseName { get; set; }
    }
}