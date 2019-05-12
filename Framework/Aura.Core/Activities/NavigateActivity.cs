using Aura.Core.AutomationDriver.Interfaces;
using Aura.Core.Interfaces;
using Aura.Core.Models;
using Aura.Core.TestReport.Interfaces;
using System;

namespace Aura.Core.Activities
{
    /// <summary>
    /// </summary>
    /// <seealso cref="Aura.Core.Activities.BaseActivity" />
    public class NavigateActivity : BaseActivity
    {
        private readonly string _argument;
        private readonly string _element;

        /// <summary>
        /// Initializes a new instance of the <see cref="NavigateActivity" /> class.
        /// </summary>
        /// <param name="step">The step.</param>
        /// <param name="reporter">The reporter.</param>
        /// <param name="driver">The driver.</param>
        /// <exception cref="System.ArgumentException">Argument</exception>
        public NavigateActivity(ITestStep step, IReporter reporter, IAutomationDriver driver)
            : base(step, reporter, driver)
        {
            if (!Uri.IsWellFormedUriString(step.Argument, UriKind.Absolute))
            {
                throw new ArgumentException($"{nameof(step.Argument)} is not a valid Uri. A valid absolute Uri must be specified.");
            }

            Action = ActivityTypes.Navigate;
            _argument = step.Argument;
            _element = step.Element;
        }

        /// <summary>
        /// Gets the action.
        /// </summary>
        /// <value>The action.</value>
        public override ActivityTypes Action { get; }

        /// <summary>
        /// Executes the internal.
        /// </summary>
        protected override void ExecuteInternal()
        {
            Driver.SeleniumWebDriver.Navigate().GoToUrl(_argument);
        }

        /// <summary>
        /// Gets the activity description.
        /// </summary>
        /// <returns></returns>
        protected override string GetActivityDescription()
        {
            return $"Navigate to {_argument}.";
        }
    }
}