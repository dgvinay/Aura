using Aura.Core.Activities;
using Aura.Core.AutomationDriver.Interfaces;
using Aura.Core.Enums;
using Aura.Core.Interfaces;
using Aura.Core.Models;
using Aura.Core.TestReport.Interfaces;
using Moq;
using OpenQA.Selenium;
using System;
using Xunit;

namespace Aura.Core.UnitTest.Activities
{
    public class NavigateActivityTests
    {
        private string _url = "http://www.google.com/";
        private readonly Mock<IAutomationDriver> _driver;
        private readonly Mock<IReporter> _reporter;

        public NavigateActivityTests()
        {
            var webDriver = new Mock<IWebDriver>();
            var navigate = new Mock<INavigation>();
            navigate.Setup(x => x.GoToUrl(_url)).Callback(() => { });

            _driver = new Mock<IAutomationDriver>();
            _driver.Setup(x => x.SeleniumWebDriver).Returns(webDriver.Object);
            _driver.Setup(x => x.SeleniumWebDriver.Navigate()).Returns(navigate.Object);

            _reporter = new Mock<IReporter>();
        }

        [Fact]
        public void MustThrowArgumentExceptionForArgument()
        {
            var testStep = new Mock<ITestStep>();

            Assert.Throws<ArgumentException>(() => new NavigateActivity(testStep.Object, _reporter.Object, _driver.Object));
        }

        [Fact]
        public void ActionPropertyMustPass()
        {
            var testStep = new Mock<ITestStep>();
            testStep.Setup(x => x.Argument).Returns(_url);

            var activity = new NavigateActivity(testStep.Object, _reporter.Object, _driver.Object);
            Assert.Equal(ActivityTypes.Navigate.Name, activity.Action.Name);
        }

        [Fact]
        public void ExecuteMustPass()
        {
            var testStep = new Mock<ITestStep>();
            testStep.Setup(x => x.Argument).Returns(_url);

            var activity = new NavigateActivity(testStep.Object, _reporter.Object, _driver.Object);
            var result = activity.Execute();

            Assert.Equal(ActivityExecutionStatus.Successful, result.Status);
        }
    }
}