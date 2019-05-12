using Aura.Core.Interfaces;
using Aura.Core.Models;
using System.Collections.Generic;

namespace Aura.Core.UnitTest.FlowTests.TestCases
{
    internal class OpenGoogleAndType : ITestCase
    {
        private readonly string _searchKey;

        public OpenGoogleAndType(string key)
        {
            _searchKey = key;

            Name = "Open google and type";
            Description = "Open google and type the search keyword";

            BuidlTestSteps();
        }

        public string Description { get; set; }

        public string Name { get; set; }

        public List<ITestStep> Steps { get; set; }

        private void BuidlTestSteps()
        {
            Steps = new List<ITestStep>
            {
                new TestStep
                {
                    Do = ActivityTypes.Navigate.Name,
                    Argument = "http://www.google.com"
                },
                new TestStep
                {
                    Do = ActivityTypes.SetValue.Name,
                    Argument = _searchKey,
                    Element = "lst-ib",
                    ElementLocator = ElementLocatorMethods.ID
                },
                new TestStep
                {
                    Do = ActivityTypes.CloseBrowser.Name,
                }
            };
        }
    }
}