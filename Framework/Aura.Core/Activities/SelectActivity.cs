using Aura.Core.AutomationDriver.Interfaces;
using Aura.Core.Interfaces;
using Aura.Core.Models;
using Aura.Core.TestReport.Interfaces;

namespace Aura.Core.Activities
{
    /// <summary>
    /// </summary>
    /// <seealso cref="Aura.Core.Activities.BaseActivity" />
    internal class SelectActivity : BaseActivity
    {
        private readonly ITestStep _step;

        /// <summary>
        /// Initializes a new instance of the <see cref="SelectActivity" /> class.
        /// </summary>
        /// <param name="step">The step.</param>
        /// <param name="reporter">The reporter.</param>
        /// <param name="driver">The driver.</param>
        public SelectActivity(ITestStep step, IReporter reporter, IAutomationDriver driver)
            : base(step, reporter, driver)
        {
            _step = step;
        }

        /// <summary>
        /// Gets the action.
        /// </summary>
        /// <value>The action.</value>
        public override ActivityTypes Action => ActivityTypes.Select;

        protected override void ExecuteInternal()
        {
            throw new System.NotImplementedException();
        }

        protected override string GetActivityDescription()
        {
            throw new System.NotImplementedException();
        }
    }
}