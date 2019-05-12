using Aura.Core.Activities;
using Aura.Core.AutomationDriver.Interfaces;
using Aura.Core.Interfaces;
using Aura.Core.Models;
using Aura.Core.TestReport.Interfaces;
using Moq;
using OpenQA.Selenium;
using Xunit;

namespace Aura.Core.UnitTest.Activities
{
    public class CloseBrowserTests
    {
        private readonly Mock<ITestStep> _testStep;
        private readonly Mock<IAutomationDriver> _driver;
        private readonly Mock<IReporter> _reporter;

        public CloseBrowserTests()
        {
            _testStep = new Mock<ITestStep>();
            _driver = new Mock<IAutomationDriver>();
            _reporter = new Mock<IReporter>();

            var webDriver = new Mock<IWebDriver>();
            _driver.Setup(x => x.SeleniumWebDriver).Returns(webDriver.Object);
        }

        [Fact]
        public void ActivityTypesPropertyMustPass()
        {
            var activity = new CloseBrowser(_testStep.Object, _reporter.Object, _driver.Object);
            Assert.Equal(ActivityTypes.CloseBrowser.Name, activity.Action.Name);
        }

        [Fact]
        public void ExecuteMustPass()
        {
            var activity = new CloseBrowser(_testStep.Object, _reporter.Object, _driver.Object);
            var result = activity.Execute();
            Assert.NotNull(result);
        }
    }
}