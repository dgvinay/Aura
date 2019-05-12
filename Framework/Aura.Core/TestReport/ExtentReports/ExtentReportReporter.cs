using Aura.Common.Extensions;
using Aura.Core.TestReport.Enums;
using Aura.Core.TestReport.Interfaces;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.IO;

namespace Aura.Core.TestReport.ExtentReports
{
    /// <summary>
    /// </summary>
    /// <seealso cref="Aura.Core.TestReport.Interfaces.IReporter" />
    public class ExtentReportReporter : IReporter
    {
        private readonly ExtentReporterOptions _options;
        private ExtentTest _currentTest;
        private string _currentTestSuiteName = "Test Suite";
        private AventStack.ExtentReports.ExtentReports _extentReport;
        private ExtentHtmlReporter _reporter;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExtentReportReporter" /> class.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <exception cref="System.ArgumentNullException">options</exception>
        public ExtentReportReporter(ExtentReporterOptions options)
        {
            _options = options ?? throw new ArgumentNullException(nameof(options));
        }

        /// <summary>
        /// Ends this instance.
        /// </summary>
        /// <returns></returns>
        public IReporter End()
        {
            _extentReport.Flush();
            _reporter.Flush();
            _reporter.Stop();

            return this;
        }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">ReportFilePath</exception>
        public IReporter Initialize()
        {
            if (string.IsNullOrEmpty(_options.ReportFilePath))
            {
                throw new ArgumentNullException(nameof(_options.ReportFilePath));
            }

            _reporter = new ExtentHtmlReporter(_options.ReportFilePath);
            _extentReport = new AventStack.ExtentReports.ExtentReports();
            _extentReport.AttachReporter(_reporter);
            _reporter.Start();

            return this;
        }

        /// <summary>
        /// News the child test case.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="description">The description.</param>
        /// <returns></returns>
        /// <exception cref="System.InvalidOperationException">Initialize</exception>
        public IReporter NewChildTestCase(string name, string description)
        {
            EnsureInitialized();

            EnsureTestCaseAdded();

            _currentTest = _currentTest.CreateNode(name, description);
            _currentTest.AssignCategory(_currentTestSuiteName);

            return this;
        }

        /// <summary>
        /// News the test case.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="description">The description.</param>
        /// <returns></returns>
        /// <exception cref="System.InvalidOperationException">Initialize</exception>
        public IReporter NewTestCase(string name, string description)
        {
            EnsureInitialized();

            _currentTest = _extentReport.CreateTest(name, description);
            _currentTest.AssignCategory(_currentTestSuiteName);

            return this;
        }

        public IReporter NewTestSuite(string suiteName)
        {
            _currentTestSuiteName = suiteName;
            return this;
        }

        #region Logs

        /// <summary>
        /// Adds the screen shot.
        /// </summary>
        /// <param name="screenshotPath">The screenshot path.</param>
        /// <param name="title">The title.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">screenshotPath</exception>
        /// <exception cref="System.IO.FileNotFoundException">Screenshot was not found.</exception>
        public IReporter AddScreenShot(string screenshotPath, string title = "")
        {
            if (!screenshotPath.HasValue())
            {
                throw new ArgumentNullException(nameof(screenshotPath));
            }

            if (!screenshotPath.IsValidFilePath())
            {
                throw new FileNotFoundException("Screenshot was not found.", screenshotPath);
            }

            EnsureTestCaseAdded();

            _currentTest.AddScreenCaptureFromPath(screenshotPath, title);
            return this;
        }

        /// <summary>
        /// Debugs the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="screenshotPath">The screenshot path.</param>
        /// <returns></returns>
        /// <exception cref="System.IO.FileNotFoundException">Screenshot was not found.</exception>
        public IReporter Debug(string message, string screenshotPath = "")
        {
            MediaEntityModelProvider provider = null;
            if (screenshotPath.HasValue() && !screenshotPath.IsValidFilePath())
            {
                throw new FileNotFoundException("Screenshot was not found.", screenshotPath);
            };

            if (screenshotPath.HasValue())
            {
                provider = MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build();
            }

            EnsureTestCaseAdded();

            _currentTest.Debug(message, provider);

            return this;
        }

        /// <summary>
        /// Errors the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="screenshotPath">The screenshot path.</param>
        /// <returns></returns>
        /// <exception cref="System.IO.FileNotFoundException">Screenshot was not found.</exception>
        public IReporter Error(string message, string screenshotPath = "")
        {
            MediaEntityModelProvider provider = null;
            if (screenshotPath.HasValue() && !screenshotPath.IsValidFilePath())
            {
                throw new FileNotFoundException("Screenshot was not found.", screenshotPath);
            };

            if (screenshotPath.HasValue())
            {
                provider = MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build();
            }

            EnsureTestCaseAdded();

            _currentTest.Error(message, provider);

            return this;
        }

        /// <summary>
        /// Exceptions the specified e.
        /// </summary>
        /// <param name="e">The e.</param>
        /// <param name="screenshotPath">The screenshot path.</param>
        /// <returns></returns>
        /// <exception cref="System.IO.FileNotFoundException">Screenshot was not found.</exception>
        public IReporter Exception(Exception e, string screenshotPath = "")
        {
            MediaEntityModelProvider provider = null;
            if (screenshotPath.HasValue() && !screenshotPath.IsValidFilePath())
            {
                throw new FileNotFoundException("Screenshot was not found.", screenshotPath);
            };

            if (screenshotPath.HasValue())
            {
                provider = MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build();
            }

            EnsureTestCaseAdded();

            _currentTest.Fatal(e, provider);
            return this;
        }

        /// <summary>
        /// Fails the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="screenshotPath">The screenshot path.</param>
        /// <returns></returns>
        /// <exception cref="System.IO.FileNotFoundException">Screenshot was not found.</exception>
        public IReporter Fail(string message, string screenshotPath = "")
        {
            MediaEntityModelProvider provider = null;
            if (screenshotPath.HasValue() && !screenshotPath.IsValidFilePath())
            {
                throw new FileNotFoundException("Screenshot was not found.", screenshotPath);
            };

            if (screenshotPath.HasValue())
            {
                provider = MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build();
            }

            EnsureTestCaseAdded();

            _currentTest.Fail(message, provider);

            return this;
        }

        /// <summary>
        /// Fatals the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="screenshotPath">The screenshot path.</param>
        /// <returns></returns>
        /// <exception cref="System.IO.FileNotFoundException">Screenshot was not found.</exception>
        public IReporter Fatal(string message, string screenshotPath = "")
        {
            MediaEntityModelProvider provider = null;
            if (screenshotPath.HasValue() && !screenshotPath.IsValidFilePath())
            {
                throw new FileNotFoundException("Screenshot was not found.", screenshotPath);
            };

            if (screenshotPath.HasValue())
            {
                provider = MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build();
            }

            EnsureTestCaseAdded();

            _currentTest.Fatal(message, provider);

            return this;
        }

        /// <summary>
        /// Informations the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="screenshotPath">The screenshot path.</param>
        /// <returns></returns>
        /// <exception cref="System.IO.FileNotFoundException">Screenshot was not found.</exception>
        public IReporter Info(string message, string screenshotPath = "")
        {
            MediaEntityModelProvider provider = null;
            if (screenshotPath.HasValue() && !screenshotPath.IsValidFilePath())
            {
                throw new FileNotFoundException("Screenshot was not found.", screenshotPath);
            };

            if (screenshotPath.HasValue())
            {
                provider = MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build();
            }

            EnsureTestCaseAdded();

            _currentTest.Info(message, provider);

            return this;
        }

        /// <summary>
        /// Logs the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="status">The status.</param>
        /// <param name="screenshotPath">The screenshot path.</param>
        /// <returns></returns>
        public IReporter Log(string message, TestReportLogStatus status, string screenshotPath = "")
        {
            switch (status)
            {
                case TestReportLogStatus.Pass: Pass(message, screenshotPath); break;
                case TestReportLogStatus.Fail: Fail(message, screenshotPath); break;
                case TestReportLogStatus.Fatal: Fatal(message, screenshotPath); break;
                case TestReportLogStatus.Error: Error(message, screenshotPath); break;
                case TestReportLogStatus.Warning: Warning(message, screenshotPath); break;
                case TestReportLogStatus.Info: Info(message, screenshotPath); break;
                case TestReportLogStatus.Skip: Skip(message, screenshotPath); break;
                case TestReportLogStatus.Debug: Debug(message, screenshotPath); break;
            }

            return this;
        }

        /// <summary>
        /// Passes the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="screenshotPath">The screenshot path.</param>
        /// <returns></returns>
        /// <exception cref="System.IO.FileNotFoundException">Screenshot was not found.</exception>
        public IReporter Pass(string message, string screenshotPath = "")
        {
            MediaEntityModelProvider provider = null;
            if (screenshotPath.HasValue() && !screenshotPath.IsValidFilePath())
            {
                throw new FileNotFoundException("Screenshot was not found.", screenshotPath);
            };

            if (screenshotPath.HasValue())
            {
                provider = MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build();
            }

            EnsureTestCaseAdded();

            _currentTest.Pass(message, provider);

            return this;
        }

        /// <summary>
        /// Skips the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="screenshotPath">The screenshot path.</param>
        /// <returns></returns>
        /// <exception cref="System.IO.FileNotFoundException">Screenshot was not found.</exception>
        public IReporter Skip(string message, string screenshotPath = "")
        {
            MediaEntityModelProvider provider = null;
            if (screenshotPath.HasValue() && !screenshotPath.IsValidFilePath())
            {
                throw new FileNotFoundException("Screenshot was not found.", screenshotPath);
            };

            if (screenshotPath.HasValue())
            {
                provider = MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build();
            }

            EnsureTestCaseAdded();

            _currentTest.Skip(message, provider);

            return this;
        }

        /// <summary>
        /// Warnings the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="screenshotPath">The screenshot path.</param>
        /// <returns></returns>
        /// <exception cref="System.IO.FileNotFoundException">Screenshot was not found.</exception>
        public IReporter Warning(string message, string screenshotPath = "")
        {
            MediaEntityModelProvider provider = null;
            if (screenshotPath.HasValue() && !screenshotPath.IsValidFilePath())
            {
                throw new FileNotFoundException("Screenshot was not found.", screenshotPath);
            };

            if (screenshotPath.HasValue())
            {
                provider = MediaEntityBuilder.CreateScreenCaptureFromPath(screenshotPath).Build();
            }

            EnsureTestCaseAdded();

            _currentTest.Warning(message, provider);

            return this;
        }

        #endregion Logs

        #region Helpers

        /// <summary>
        /// Ensures the initialized.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">Initialize</exception>
        private void EnsureInitialized()
        {
            if (_extentReport.IsNull())
            {
                throw new InvalidOperationException($"{nameof(Initialize)} method needs to be called before performing any other operation.");
            }
        }

        /// <summary>
        /// Ensures the test case added.
        /// </summary>
        /// <exception cref="System.InvalidOperationException"></exception>
        private void EnsureTestCaseAdded()
        {
            if (_currentTest.IsNull())
            {
                throw new InvalidOperationException($"Test Case needs to be added before performing any actions related to TestCase.");
            }
        }

        #endregion Helpers
    }
}