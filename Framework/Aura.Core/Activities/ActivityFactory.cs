using Aura.Core.AutomationDriver.Interfaces;
using Aura.Core.Interfaces;
using Aura.Core.Models;
using Aura.Core.TestReport.Interfaces;

using System;
using System.Collections.Generic;

namespace Aura.Core.Activities
{
    /// <summary>
    /// </summary>
    public class ActivityFactory
    {
        private Dictionary<string, Type> _activities;
        private static ActivityFactory _instance = new ActivityFactory();

        /// <summary>
        /// Initializes a new instance of the <see cref="ActivityFactory" /> class.
        /// </summary>
        private ActivityFactory()
        {
            _activities = new Dictionary<string, Type>
            {
                {
                    ActivityTypes.Navigate.Name,  typeof(NavigateActivity)
                },
                {
                    ActivityTypes.SetValue.Name, typeof(SetValueActivity)
                },
                {
                    ActivityTypes.Click.Name, typeof(ClickActivity)
                },
                {
                    ActivityTypes.Select.Name, typeof(SetValueActivity)
                },
                {
                    ActivityTypes.CloseBrowser.Name, typeof(CloseBrowser)
                }
            };
        }

        /// <summary>
        /// Gets the activity.
        /// </summary>
        /// <param name="step">The step.</param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">Do</exception>
        public static IActivity GetActivity(ITestStep step, IReporter reporter, IAutomationDriver driver)
        {
            if (_instance._activities.ContainsKey(step.Do))
            {
                var activityType = _instance._activities[step.Do];
                return (IActivity)Activator.CreateInstance(activityType, step, reporter, driver);
            }

            throw new InvalidOperationException($"Invalid activity {nameof(step.Do)}");
        }

        /// <summary>
        /// Registers the activity.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="activityType">Type of the activity.</param>
        public static void RegisterActivity<T>(ActivityTypes activityType) where T : IActivity
        {
            _instance._activities.Add(activityType.Name, typeof(T));
        }
    }
}