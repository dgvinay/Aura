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
    public class TestExecutionEngineTests
    {
        private readonly Mock<IAutomationDriver> _driver;
        private readonly Mock<IReporter> _reporter;

        public TestExecutionEngineTests()
        {
            _driver = new Mock<IAutomationDriver>();
            _reporter = new Mock<IReporter>();
        }

        [Fact]
        public void InitializationNullDriver()
        {
            Assert.Throws<ArgumentNullException>(() => new TestExecutionEngine(null, _reporter.Object));
        }

        [Fact]
        public void InitializationNullReport()
        {
            Assert.Throws<ArgumentNullException>(() => new TestExecutionEngine(_driver.Object, null));
        }

        [Fact]
        public void AddTestCaseNullCheck()
        {
            var engine = new TestExecutionEngine(_driver.Object, _reporter.Object);

            Assert.Throws<ArgumentNullException>(() => engine.AddTestCase(null));
        }

        [Fact]
        public void AddTestCaseMustPass()
        {
            var testCase = new Mock<ITestCase>();
            var engine = new TestExecutionEngine(_driver.Object, _reporter.Object);
            var result = engine.AddTestCase(testCase.Object);

            Assert.NotNull(result);
        }

        [Fact]
        public void AddTestCasesNullCheck()
        {
            var engine = new TestExecutionEngine(_driver.Object, _reporter.Object);

            Assert.Throws<ArgumentNullException>(() => engine.AddTestCases(null));
        }

        [Fact]
        public void AddTestCasesMustPass()
        {
            var testCase1 = new Mock<ITestCase>();
            var testCase2 = new Mock<ITestCase>();

            var testCases = new List<ITestCase> { testCase1.Object, testCase2.Object };

            var engine = new TestExecutionEngine(_driver.Object, _reporter.Object);
            var result = engine.AddTestCases(testCases.ToArray());

            Assert.NotNull(result);
        }

        [Fact]
        public void FireMustPass()
        {
            var webDriver = new Mock<IWebDriver>();
            var navigate = new Mock<INavigation>();

            webDriver.Setup(x => x.Navigate()).Returns(navigate.Object);

            _driver.Setup(x => x.SeleniumWebDriver).Returns(webDriver.Object);

            var testCase1 = new Mock<ITestCase>();
            var testCase2 = new Mock<ITestCase>();
            var testStep = new Mock<ITestStep>();

            testStep.Setup(x => x.Do).Returns(ActivityTypes.Navigate.Name);
            testStep.Setup(x => x.Argument).Returns("https://www.google.com");

            testCase1.Setup(x => x.Steps).Returns(new List<ITestStep> { testStep.Object });
            testCase2.Setup(x => x.Steps).Returns(new List<ITestStep> { testStep.Object });

            var testCases = new List<ITestCase> { testCase1.Object, testCase2.Object };

            var engine = new TestExecutionEngine(_driver.Object, _reporter.Object);
            engine.AddTestCases(testCases.ToArray());

            var result = engine.Fire();

            Assert.NotNull(result);
        }
    }
}