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
    public class SetValueActivityTests
    {
        private readonly Mock<IAutomationDriver> _driver;
        private readonly Mock<IReporter> _reporter;
        private readonly Mock<IWebDriver> _webDriver;

        public SetValueActivityTests()
        {
            _webDriver = new Mock<IWebDriver>();
            _driver = new Mock<IAutomationDriver>();
            _driver.Setup(x => x.SeleniumWebDriver).Returns(_webDriver.Object);

            _reporter = new Mock<IReporter>();
        }

        [Fact]
        public void NoElementMustThrowException()
        {
            var testStep = new Mock<ITestStep>();

            Assert.Throws<ArgumentNullException>(() => new SetValueActivity(testStep.Object, _reporter.Object, _driver.Object));
        }

        [Fact]
        public void NoElementLocatorMustThrowException()
        {
            var testStep = new Mock<ITestStep>();

            testStep.Setup(x => x.Element).Returns("Element");

            Assert.Throws<InvalidOperationException>(() => new SetValueActivity(testStep.Object, _reporter.Object, _driver.Object));
        }

        [Fact]
        public void NoArgumentMustThrowException()
        {
            var driver = new Mock<IAutomationDriver>();
            var testStep = new Mock<ITestStep>();

            testStep.Setup(x => x.Element).Returns("Element");
            testStep.Setup(x => x.ElementLocator).Returns(ElementLocatorMethods.ID);

            var webDriver = new Mock<IWebDriver>();
            driver.Setup(x => x.SeleniumWebDriver).Returns(webDriver.Object);

            Assert.Throws<ArgumentNullException>(() => new SetValueActivity(testStep.Object, _reporter.Object, driver.Object));
        }

        [Fact]
        public void ActionPropertyMustPass()
        {
            var testStep = new Mock<ITestStep>();
            testStep.Setup(x => x.Element).Returns("ElementName");
            testStep.Setup(x => x.ElementLocator).Returns(ElementLocatorMethods.ID);
            testStep.Setup(x => x.Argument).Returns("Test");

            var activity = new SetValueActivity(testStep.Object, _reporter.Object, _driver.Object);
            Assert.Equal(ActivityTypes.SetValue.Name, activity.Action.Name);
        }

        [Fact]
        public void ExecuteMustPass()
        {
            var testStep = new Mock<ITestStep>();
            var webElement = new Mock<IWebElement>();

            testStep.Setup(x => x.Element).Returns("ElementName");
            testStep.Setup(x => x.ElementLocator).Returns(ElementLocatorMethods.ID);
            testStep.Setup(x => x.Argument).Returns("Test");

            //driver.Setup(x => x.SeleniumWebDriver.FindElement(ElementLocatorMethods.ID, "ElementName")).Returns(webElement.Object);

            var activity = new SetValueActivity(testStep.Object, _reporter.Object, _driver.Object);
            var result = activity.Execute();

            //Assert.Equal(ActivityExecutionStatus.Successful, result.Status);
        }
    }
}