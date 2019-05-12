using Aura.Core.Interfaces;
using Aura.Core.Models;
using System.Collections.Generic;

namespace Aura.Core.UnitTest.FlowTests.TestCases
{
    internal class OpenGoogleWebsite : ITestCase
    {
        public OpenGoogleWebsite()
        {
            Name = "Open http://www.google.com";
            Description = "Open the browser and navigate to http://www.google.com";
            BuildTestSteps();
        }

        public string Description { get; set; }

        public string Name { get; set; }

        public List<ITestStep> Steps { get; set; }

        private void BuildTestSteps()
        {
            Steps = new List<ITestStep>
            {
                new TestStep
                {
                    Do = ActivityTypes.Navigate.Name,
                    Argument = "http://www.google.com/",
                },
                new TestStep
                {
                    Do = ActivityTypes.CloseBrowser.Name
                }
            };
        }
    }
}