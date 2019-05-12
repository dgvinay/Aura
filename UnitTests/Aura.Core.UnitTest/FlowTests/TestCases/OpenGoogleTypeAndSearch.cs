using Aura.Core.Interfaces;
using Aura.Core.Models;
using System.Collections.Generic;

namespace Aura.Core.UnitTest.FlowTests.TestCases
{
    public class OpenGoogleTypeAndSearch : ITestCase
    {
        private readonly string _searchKey;

        public OpenGoogleTypeAndSearch(string searchKey)
        {
            Name = "Open google type and search";
            Description = "Open google type automation and click on search button";
            _searchKey = searchKey;

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
                    Argument = "http://www.google.com"
                },
                new TestStep
                {
                    Do = ActivityTypes.SetValue.Name,
                    Argument = _searchKey,
                    Element = "lst-ib",
                    ElementLocator = ElementLocatorMethods.ID
                },
                //new TestStep
                //{
                //    Do = ActivityTypes.Click.Name,
                //    Element = "lga",
                //    ElementLocator = ElementLocatorMethods.ID
                //},
                new TestStep
                {
                    Do = ActivityTypes.Click.Name,
                    Element = "btnK",
                    ElementLocator = ElementLocatorMethods.Name
                },
                new TestStep
                {
                    Do = ActivityTypes.CloseBrowser.Name
                }
            };
        }
    }
}