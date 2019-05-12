using Aura.Core.AutomationDriver.Interfaces;
using Aura.Core.Interfaces;
using Aura.Core.Models;
using Aura.Core.TestReport.Interfaces;

namespace Aura.Core.Activities
{
    /// <summary>
    /// </summary>
    /// <seealso cref="Aura.Core.Activities.BaseActivity" />
    public class CloseBrowser : BaseActivity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CloseBrowser" /> class.
        /// </summary>
        /// <param name="step">The step.</param>
        /// <param name="reporter">The reporter.</param>
        /// <param name="driver">The driver.</param>
        public CloseBrowser(ITestStep step, IReporter reporter, IAutomationDriver driver)
            : base(step, reporter, driver)
        {
        }

        /// <summary>
        /// Gets the action.
        /// </summary>
        /// <value>The action.</value>
        public override ActivityTypes Action => ActivityTypes.CloseBrowser;

        /// <summary>
        /// Executes this instance.
        /// </summary>
        protected override void ExecuteInternal()
        {
            Driver.SeleniumWebDriver.Close();
        }

        protected override string GetActivityDescription()
        {
            return $"Close the browser.";
        }
    }
}