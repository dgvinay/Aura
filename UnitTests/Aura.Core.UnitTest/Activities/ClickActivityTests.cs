using Aura.Core.Activities;
using Aura.Core.AutomationDriver.Interfaces;
using Aura.Core.Interfaces;
using Aura.Core.Models;
using Aura.Core.TestReport.Interfaces;
using Moq;
using OpenQA.Selenium;
using System;
using Xunit;

namespace Aura.Core.UnitTest.Activities
{
    public class ClickActivityTests
    {
        private readonly Mock<IAutomationDriver> _driver;
        private readonly Mock<IReporter> _reporter;
        private readonly Mock<IWebDriver> _webDriver;

        public ClickActivityTests()
        {
            _webDriver = new Mock<IWebDriver>();
            _driver = new Mock<IAutomationDriver>();
            _driver.Setup(x => x.SeleniumWebDriver).Returns(_webDriver.Object);

            _reporter = new Mock<IReporter>();
        }

        [Fact]
        public void MustThrowArgumentNullExceptionForElement()
        {
            var testStep = new Mock<ITestStep>();

            Assert.Throws<ArgumentNullException>(() => new ClickActivity(testStep.Object, _reporter.Object, _driver.Object));
        }

        [Fact]
        public void MustThrowArgumentExceptionForElement()
        {
            var testStep = new Mock<ITestStep>();
            testStep.Setup(x => x.Element).Returns("ElementName");
            testStep.Setup(x => x.ElementLocator).Returns(ElementLocatorMethods.None);

            Assert.Throws<ArgumentException>(() => new ClickActivity(testStep.Object, _reporter.Object, _driver.Object));
        }

        [Fact]
        public void ActionPropertyMustPass()
        {
            var testStep = new Mock<ITestStep>();
            testStep.Setup(x => x.Element).Returns("ElementName");
            testStep.Setup(x => x.ElementLocator).Returns(ElementLocatorMethods.ID);

            var activity = new ClickActivity(testStep.Object, _reporter.Object, _driver.Object);
            Assert.Equal(ActivityTypes.Click.Name, activity.Action.Name);
        }

        [Fact]
        public void MustThrowArgumentNullExceptionForWebDriver()
        {
            var testStep = new Mock<ITestStep>();
            var driver = new Mock<IAutomationDriver>();

            testStep.Setup(x => x.Element).Returns("ElementName");
            testStep.Setup(x => x.ElementLocator).Returns(ElementLocatorMethods.ID);

            Assert.Throws<ArgumentNullException>(() => new ClickActivity(testStep.Object, _reporter.Object, driver.Object));
        }

        [Fact]
        public void ExecuteElementNotFoundMustPass()
        {
            //var testStep = new Mock<ITestStep>();

            //testStep.Setup(x => x.Element).Returns("ElementName");
            //testStep.Setup(x => x.ElementLocator).Returns(ElementLocatorMethods.ID);

            //_driver.Setup(x => x.SeleniumWebDriver).Returns(new RemoteWebDriver(new ChromeOptions()));

            //var activity = new ClickActivity(testStep.Object, _reporter.Object, _driver.Object);
            //var result = activity.Execute();

            //Assert.Equal(ActivityExecutionStatus.Failed, result.Status);
        }
    }
}