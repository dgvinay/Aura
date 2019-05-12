using Aura.Core.AutomationDriver.Interfaces;
using Aura.Core.Interfaces;
using Aura.Core.Models;
using Aura.Core.Runtime.Interfaces;
using Aura.Core.TestReport.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aura.Core
{
    /// <summary>
    /// </summary>
    public class TestExecutionEngine : ITestExecutionEngine
    {
        private const string DEFAULT_SUITE_NAME = "Default Suite";
        private readonly IAutomationDriver _driver;
        private readonly IReporter _reporter;
        private readonly ITestExecutionRuntime _runtime;
        private readonly IList<ITestSuite> _testSuites;

        /// <summary>
        /// Initializes a new instance of the <see cref="TestExecutionEngine" /> class.
        /// </summary>
        /// <param name="testCase">The test case.</param>
        public TestExecutionEngine(
            IAutomationDriver driver,
            IReporter reporter)
        {
            _driver = driver ?? throw new ArgumentNullException(nameof(driver));
            _reporter = reporter ?? throw new ArgumentNullException(nameof(reporter));
            _runtime = new TestExecutionRuntime(_driver, reporter);
            _testSuites = new List<ITestSuite>
            {
                new TestSuite
                {
                    Name = DEFAULT_SUITE_NAME,
                    TestCases = new List<ITestCase>()
                }
            };
        }

        /// <summary>
        /// Adds the test case.
        /// </summary>
        /// <param name="testCase">The test case.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">testCase</exception>
        public TestExecutionEngine AddTestCase(ITestCase testCase)
        {
            if (testCase == null)
            {
                throw new ArgumentNullException(nameof(testCase));
            }

            _testSuites.First(s => s.Name == DEFAULT_SUITE_NAME)
                       .TestCases
                       .Add(testCase);

            return this;
        }

        /// <summary>
        /// Adds the test cases.
        /// </summary>
        /// <param name="testCases">The test cases.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">testCases</exception>
        public TestExecutionEngine AddTestCases(params ITestCase[] testCases)
        {
            if (testCases == null || testCases.Length == 0)
            {
                throw new ArgumentNullException(nameof(testCases));
            }

            _testSuites.First(s => s.Name == DEFAULT_SUITE_NAME)
                        .TestCases
                        .AddRange(testCases);

            return this;
        }

        /// <summary>
        /// Fires this instance.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TestExecutionResult> Fire()
        {
            List<TestExecutionResult> result = new List<TestExecutionResult>();
            _reporter.Initialize();

            foreach (var suite in _testSuites)
            {
                _reporter.NewTestSuite(suite.Name);
                foreach (var testCase in suite.TestCases)
                {
                    result.Add(_runtime.Execute(testCase));
                }
            }

            _reporter.End();
            _driver.Close();

            return result;
        }
    }
}