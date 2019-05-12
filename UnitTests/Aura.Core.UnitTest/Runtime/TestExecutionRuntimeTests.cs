using Aura.Core.AutomationDriver.Interfaces;
using Aura.Core.Interfaces;
using Aura.Core.Models;
using Aura.Core.TestReport.Interfaces;
using Moq;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using Xunit;

namespace Aura.Core.UnitTest.Runtime
{
    public class TestExecutionRuntimeTests
    {
        private readonly Mock<IAutomationDriver> _driver;
        private readonly Mock<IReporter> _reporter;

        public TestExecutionRuntimeTests()
        {
            _driver = new Mock<IAutomationDriver>();
            _reporter = new Mock<IReporter>();
        }

        [Fact]
        public void ExecuteMustPass()
        {
            var testCase = new Mock<ITestCase>();
            var testStep = new Mock<ITestStep>();
            var webDriver = new Mock<IWebDriver>();
            var navigate = new Mock<INavigation>();

            webDriver.Setup(x => x.Navigate()).Returns(navigate.Object);

            _driver.Setup(x => x.SeleniumWebDriver).Returns(webDriver.Object);

            var runtime = new TestExecutionRuntime(_driver.Object, _reporter.Object);

            testStep.Setup(x => x.Do).Returns(ActivityTypes.Navigate.Name);
            testStep.Setup(x => x.Argument).Returns("https://www.google.com");

            testCase.Setup(x => x.Steps).Returns(new List<ITestStep> { testStep.Object });

            var resultSet = runtime.Execute(testCase.Object);

            Assert.NotNull(resultSet);
        }

        [Fact]
        public void ExecuteTestCaseWithNoSteps()
        {
            var testCase = new Mock<ITestCase>();
            var runtime = new TestExecutionRuntime(_driver.Object, _reporter.Object);
            Assert.Throws<ArgumentNullException>(() => runtime.Execute(testCase.Object));
        }

        [Fact]
        public void ExecuteWithNullTestCase()
        {
            var runtime = new TestExecutionRuntime(_driver.Object, _reporter.Object);
            Assert.Throws<ArgumentNullException>(() => runtime.Execute(null));
        }

        [Fact]
        public void InitializationNullDriver()
        {
            Assert.Throws<ArgumentNullException>(() => new TestExecutionRuntime(null, _reporter.Object));
        }

        [Fact]
        public void InitializationNullReporter()
        {
            Assert.Throws<ArgumentNullException>(() => new TestExecutionRuntime(_driver.Object, null));
        }
    }
}