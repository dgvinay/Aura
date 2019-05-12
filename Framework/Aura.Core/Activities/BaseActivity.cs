using Aura.Core.AutomationDriver.Interfaces;
using Aura.Core.Interfaces;
using Aura.Core.Models;
using Aura.Core.TestReport.Interfaces;
using System;

namespace Aura.Core.Activities
{
    /// <summary>
    /// </summary>
    /// <seealso cref="Aura.Core.Interfaces.IActivity" />
    public abstract class BaseActivity : IActivity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseActivity" /> class.
        /// </summary>
        /// <param name="step">The step.</param>
        /// <param name="reporter">The reporter.</param>
        /// <param name="driver">The driver.</param>
        /// <exception cref="System.ArgumentNullException">
        /// reporter or step or SeleniumWebDriver or driver
        /// </exception>
        public BaseActivity(ITestStep step,
                            IReporter reporter,
                            IAutomationDriver driver)
        {
            Reporter = reporter ?? throw new ArgumentNullException(nameof(reporter));
            TestStep = step ?? throw new ArgumentNullException(nameof(step));
            Driver = driver ?? throw new ArgumentNullException(nameof(driver));

            if (driver.SeleniumWebDriver == null)
            {
                throw new ArgumentNullException(nameof(driver.SeleniumWebDriver));
            }

            Result = new ActivityExecutionResult();
        }

        /// <summary>
        /// Gets the action.
        /// </summary>
        /// <value>The action.</value>
        public abstract ActivityTypes Action { get; }

        /// <summary>
        /// Gets the driver.
        /// </summary>
        /// <value>The driver.</value>
        protected IAutomationDriver Driver { get; private set; }

        /// <summary>
        /// Gets the reporter.
        /// </summary>
        /// <value>The reporter.</value>
        protected IReporter Reporter { get; private set; }

        protected IActivityExecutionResult Result { get; set; }

        /// <summary>
        /// Gets the test step.
        /// </summary>
        /// <value>The test step.</value>
        protected ITestStep TestStep { get; private set; }

        /// <summary>
        /// Executes this instance.
        /// </summary>
        public IActivityExecutionResult Execute()
        {
            try
            {
                ExecuteInternal();
                Reporter.Pass(GetActivityDescription());
            }
            catch (Exception e)
            {
                Reporter.Fail(GetActivityDescription());
                Result.Exception = e;
                Result.Status = Enums.ActivityExecutionStatus.Failed;
                var screenshotPath = Driver.CaptureScreenshotToFile();
                Reporter.Exception(e, screenshotPath);
            }

            return Result;
        }

        /// <summary>
        /// Executes the internal.
        /// </summary>
        protected abstract void ExecuteInternal();

        /// <summary>
        /// Gets the activity description.
        /// </summary>
        /// <returns></returns>
        protected abstract string GetActivityDescription();
    }
}