using Aura.Core.AutomationDriver.Interfaces;
using Aura.Core.Enums;
using Aura.Core.Extensions;
using Aura.Core.Interfaces;
using Aura.Core.Models;
using Aura.Core.TestReport.Interfaces;
using System;

namespace Aura.Core.Activities
{
    public class SetValueActivity : BaseActivity
    {
        private readonly string _argument;
        private readonly string _element;
        private readonly ElementLocatorMethods _elementLocator;

        /// <summary>
        /// Initializes a new instance of the <see cref="SetValueActivity" /> class.
        /// </summary>
        /// <param name="step">The step.</param>
        /// <param name="reporter">The reporter.</param>
        /// <param name="driver">The driver.</param>
        /// <exception cref="System.ArgumentNullException">Element or Argument</exception>
        /// <exception cref="System.InvalidOperationException"></exception>
        public SetValueActivity(ITestStep step, IReporter reporter, IAutomationDriver driver)
            : base(step, reporter, driver)
        {
            if (string.IsNullOrEmpty(step.Element))
            {
                throw new ArgumentNullException(nameof(step.Element));
            }

            if (step.ElementLocator == ElementLocatorMethods.None)
            {
                throw new InvalidOperationException($"Invalid ElementLocator: {step.ElementLocator}");
            }

            if (string.IsNullOrEmpty(step.Argument))
            {
                throw new ArgumentNullException(nameof(step.Argument));
            }

            _element = step.Element;
            _argument = step.Argument;
            _elementLocator = step.ElementLocator;
        }

        /// <summary>
        /// Gets the action.
        /// </summary>
        /// <value>The action.</value>
        public override ActivityTypes Action => ActivityTypes.SetValue;

        /// <summary>
        /// Executes this instance.
        /// </summary>
        /// <returns></returns>
        protected override void ExecuteInternal()
        {
            try
            {
                Driver.SeleniumWebDriver.FindElement(_elementLocator, _element)?.SendKeys(_argument);
            }
            catch (Exception e)
            {
                Result.Exception = e;
                Result.Status = ActivityExecutionStatus.Failed;
            }
        }

        /// <summary>
        /// Gets the activity description.
        /// </summary>
        /// <returns></returns>
        protected override string GetActivityDescription()
        {
            return $"Set value of {_element} to {_argument}.";
        }
    }
}