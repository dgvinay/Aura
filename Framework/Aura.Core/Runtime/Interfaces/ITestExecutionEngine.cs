using Aura.Core.Interfaces;
using Aura.Core.Models;
using System.Collections.Generic;

namespace Aura.Core.Runtime.Interfaces
{
    /// <summary>
    /// </summary>
    public interface ITestExecutionEngine
    {
        /// <summary>
        /// Adds the test case.
        /// </summary>
        /// <param name="testCase">The test case.</param>
        /// <returns></returns>
        TestExecutionEngine AddTestCase(ITestCase testCase);

        /// <summary>
        /// Adds the test cases.
        /// </summary>
        /// <param name="testCases">The test cases.</param>
        /// <returns></returns>
        TestExecutionEngine AddTestCases(params ITestCase[] testCases);

        /// <summary>
        /// Fires this instance.
        /// </summary>
        /// <returns></returns>
        IEnumerable<TestExecutionResult> Fire();
    }
}