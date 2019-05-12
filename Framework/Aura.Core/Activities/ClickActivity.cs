using Aura.Core.AutomationDriver.Interfaces;
using Aura.Core.Extensions;
using Aura.Core.Interfaces;
using Aura.Core.Models;
using Aura.Core.TestReport.Interfaces;
using System;

namespace Aura.Core.Activities
{
    public class ClickActivity : BaseActivity
    {
        private readonly string _element;
        private readonly ElementLocatorMethods _elementLocator;

        /// <summary>
        /// Initializes a new instance of the <see cref="ClickActivity" /> class.
        /// </summary>
        /// <param name="step">The step.</param>
        /// <param name="reporter"></param>
        /// <param name="driver"></param>
        /// <exception cref="System.ArgumentNullException">Element</exception>
        /// <exception cref="System.ArgumentException">Invalid value specified. - ElementLocator</exception>
        public ClickActivity(
            ITestStep step,
            IReporter reporter,
            IAutomationDriver driver)
            : base(step, reporter, driver)
        {
            if (string.IsNullOrEmpty(step.Element))
            {
                throw new ArgumentNullException(nameof(step.Element));
            }

            if (step.ElementLocator == ElementLocatorMethods.None)
            {
                throw new ArgumentException("Invalid value specified.", nameof(step.ElementLocator));
            }

            _element = step.Element;
            _elementLocator = step.ElementLocator;
        }

        /// <summary>
        /// Gets the action.
        /// </summary>
        /// <value>The action.</value>
        public override ActivityTypes Action => ActivityTypes.Click;

        /// <summary>
        /// Executes this instance.
        /// </summary>
        /// <returns></returns>
        protected override void ExecuteInternal()
        {
            var element = Driver.SeleniumWebDriver.FindElement(_elementLocator, _element);

            if (element == null)
            {
                throw new Exception(_element);
            }
            else
            {
                element.Click();
            }
        }

        protected override string GetActivityDescription()
        {
            return $"Click on {_element}.";
        }
    }
}