using Aura.Common.Extensions;
using Aura.Core.Activities;
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
    public class TestExecutionRuntime : ITestExecutionRuntime
    {
        private readonly IAutomationDriver _driver;
        private readonly IReporter _reporter;

        /// <summary>
        /// Initializes a new instance of the <see cref="TestExecutionRuntime" /> class.
        /// </summary>
        /// <param name="driver">The driver.</param>
        /// <param name="reporter">The reporter.</param>
        /// <exception cref="ArgumentNullException">driver or reporter</exception>
        public TestExecutionRuntime(
            IAutomationDriver driver,
            IReporter reporter)
        {
            _driver = driver ?? throw new ArgumentNullException(nameof(driver));
            _reporter = reporter ?? throw new ArgumentNullException(nameof(reporter));
        }

        /// <summary>
        /// Executes the specified test suite.
        /// </summary>
        /// <param name="testSuite">The test suite.</param>
        /// <returns></returns>
        public TestExecutionResult Execute(ITestCase testCase)
        {
            testCase.EnsureNotNull(nameof(testCase));

            testCase.Steps.EnsureNotNull(nameof(testCase.Steps));

            var result = new TestExecutionResult
            {
                TestCaseName = testCase.Name,
                Status = Enums.TestExecutionStatus.Successful
            };

            _reporter.NewTestCase(testCase.Name, testCase.Description);
            var activityResultSet = new List<IActivityExecutionResult>();
            foreach (var step in testCase.Steps)
            {
                string activityDescription = string.Empty;
                IActivityExecutionResult activityResult;
                try
                {
                    var activity = ActivityFactory.GetActivity(step, _reporter, _driver);
                    activityResult = activity.Execute();
                    activityResultSet.Add(activityResult);
                    if (activityResult.Status == Enums.ActivityExecutionStatus.Failed)
                    {
                        break;
                    }
                }
                catch (Exception e)
                {
                    result.Status = Enums.TestExecutionStatus.Failed;
                    _reporter.Exception(e);
                    break;
                }
            }

            if (activityResultSet.Any(r => r.Status == Enums.ActivityExecutionStatus.Failed))
            {
                _reporter.Fail($"{testCase.Name} failed.");
                result.Status = Enums.TestExecutionStatus.Failed;
            }
            else
            {
                _reporter.Pass($"{testCase.Name} passed.");
            }

            return result;
        }
    }
}