using Aura.Core.TestReport.ExtentReports;
using Aura.Core.UnitTest.Common;
using System;
using Xunit;

namespace Aura.Core.UnitTest.TestReport.ExtentReports
{
    public class ExtentReportReporterTests
    {
        private readonly string _reportDirectory;

        public ExtentReportReporterTests()
        {
            _reportDirectory = Constants.REPORTS_PATH;
        }

        #region Instantiation

        [Fact]
        public void InstantiationWithOptionsAsNull()
        {
            Assert.Throws<ArgumentNullException>(() => new ExtentReportReporter(null));
        }

        #endregion Instantiation

        #region Initialize

        [Fact]
        public void InitializeWithEmptyReportPath()
        {
            var reporter = new ExtentReportReporter(new ExtentReporterOptions());
            Assert.Throws<ArgumentNullException>(() => reporter.Initialize());
        }

        #endregion Initialize

        #region AddTestCase

        [Fact]
        public void Logs()
        {
            var reporter = Reporter.GetReporter("Logs");
            reporter.Initialize();
            reporter.NewTestCase("All Logs Test", "This should contain all kinds of logs");

            reporter.Debug("debug message");
            reporter.Error("debug message");
            reporter.Exception(new Exception("Test exception"));
            reporter.Fail("debug message");
            reporter.Fatal("debug message");
            reporter.Info("debug message");
            reporter.Pass("debug message");
            reporter.Skip("debug message");
            reporter.Warning("debug message");

            reporter.End();
        }

        [Fact]
        public void NewChildTestCase()
        {
            var reporter = Reporter.GetReporter("NewChildTestCase");
            reporter.Initialize();
            var parentTestCase = reporter.NewTestCase("Parent TestCase", "description");
            parentTestCase.Info("some information");

            var childTestCase = parentTestCase.NewChildTestCase("child test case", "description");
            childTestCase.Info("some more information");

            reporter.End();
        }

        [Fact]
        public void NewTestCase()
        {
            var reporter = Reporter.GetReporter("NewTestCase");
            reporter.Initialize();
            reporter.NewTestCase("NewTestCase", "description");
            reporter.End();
        }

        [Fact]
        public void NewTestCaseWithOutInitialize()
        {
            var reporter = Reporter.GetReporter("NewTestCaseWithOutInitialize");
            Assert.Throws<InvalidOperationException>(() => reporter.NewTestCase("", ""));
        }

        [Fact]
        public void NewTestSuite()
        {
            var reporter = Reporter.GetReporter("Multiple suites");
            reporter.Initialize();

            reporter.NewTestSuite("Suite 1");
            reporter.NewTestCase("Test Case 1", "Test case 1 description");
            reporter.Info("Step 1");
            reporter.Info("Step 2");
            reporter.Info("Step 3");

            reporter.NewTestSuite("Suite 2");
            reporter.NewTestCase("Test Case 1", "Test case 1 description");
            reporter.Info("Step 1");
            reporter.Info("Step 2");
            reporter.Info("Step 3");

            reporter.End();
        }

        #endregion AddTestCase
    }
}